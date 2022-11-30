using TestProject.Interfaces;
using TestProject.Entities;

namespace TestProject.Models
{
    public class ShoppingEventItem
    {
        public ShoppingEventItem(string name, double quantity, double pricePerQuantity, bool isQuantityCount, double discount)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.PricePerQuantity = pricePerQuantity;
            this.IsQuantityCount = isQuantityCount;
            this.Discount = discount;
        }
   
        public ShoppingEventItem(string name, double weight, double pricePerWeight) : this(name, weight, pricePerWeight, false, 0)
        {}
        public ShoppingEventItem(string name, int count, double pricePerCount) : this(name, count, pricePerCount, true, 0)
        {}

        public string ReceiptLineItem => string.Format("{0}, {1} {2}  {3} {4}",
           this.ReceiptLineItemName, this.ReceiptLineItemPricePerQuantity, this.ReceiptLineItemQuantity, this.ReceiptLineItemTotalPrice, this.ReceiptLineItemDiscount);
        private string ReceiptLineItemTotalPrice => string.Format("{0} {1}", this.OrdinaryPrice, this.Currency);
        private string ReceiptLineItemName => this.Name;
        private string ReceiptLineItemDiscount => this.HasDiscount ? string.Format("{0} -{1} {2}", this.DiscountAttribute, this.Discount, this.Currency) : string.Empty;
        private bool HasDiscount => this.Discount > 0;
        private string ReceiptLineItemPricePerQuantity => string.Format("({0} {1})", this.PricePerQuantity, this.IsQuantityCount ? this.Currency + " each" : this.Currency+"/" +this.QuantityMetric);
        private string ReceiptLineItemQuantity => string.Format("{0} {1}", this.Quantity, this.IsQuantityCount ? "pz" : "kg");
        private string Currency => CashRegister.Settings.Currency;
        private string QuantityMetric => this.IsQuantityCount ? CashRegister.Settings.CountMetric : CashRegister.Settings.WeightMetric;
        private bool IsQuantityCount;
        public string Name { get; } 
        public double TotalPrice => this.OrdinaryPrice - this.Discount;
        private double OrdinaryPrice => this.Quantity * this.PricePerQuantity;
        private double Discount;
        private double Quantity;
        protected string QuantityAndMetric => this.Quantity + " " + this.QuantityMetric;
        protected double PricePerQuantity;

        public ReceiptLineItemEntity ReceiptLineEntity
            => new ReceiptLineItemEntity { Discount = this.Discount,  Name = this.Name, IsQuantityCount = this.IsQuantityCount, PricePerQuanity = this.PricePerQuantity, Quantity = this.Quantity };
        public bool IsSameItem(ShoppingEventItem item) => item.Name == this.Name;
        public void UpdateQuantity(ShoppingEventItem item) => this.Quantity += item.Quantity;

        protected string DiscountAttribute;

        public void ApplyOffer(IOfferService offerService)
        {
            var checkForOfferResult = offerService.CheckForOffer(this.Name, this.Quantity, this.PricePerQuantity, this.IsQuantityCount);
            if (checkForOfferResult.HasOffer)
            {
                this.Discount = checkForOfferResult.Discount;
                this.DiscountAttribute = checkForOfferResult.OfferAtribute;
                CashRegister.LoggService?.AddOfferEntry(this.Name, this.QuantityAndMetric, this.DiscountAttribute, offerService.AdditionalDetailsForLogging);
            }
        }
    }
}
