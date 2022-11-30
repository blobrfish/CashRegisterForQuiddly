namespace TestProject.Interfaces
{
    public interface IOfferService
    {
        /// <summary>
        /// Loads offers. Must be called before service can be used
        /// </summary>
        void LoadOffers();

        /// <summary>
        /// Gets the price of an item 
        /// </summary>
        /// <param name="itemName">Name of the item</param>
        /// <param name="quantity">Quantity of the item</param>
        /// <param name="pricePerQuantity">Price per quantity of the item</param>
        /// <param name="isQuantityCount">True if quantity is count, false if weight</param>
        /// <returns>the result of a offer check</returns>
        CheckOfferResult CheckForOffer(string itemName, double quantity, double pricePerQuantity, bool isQuantityCount);

        /// <summary>
        /// Gets additional details if relevant 
        /// </summary>
    
        string AdditionalDetailsForLogging { get; }
    }

    public struct CheckOfferResult
    {
        public bool HasOffer { get; set; }
        public double Discount { get; set; }
        public string OfferAtribute { get; set; }

        public CheckOfferResult(bool hasOffer, string offerAtribute, double discount)
        {
            this.HasOffer = hasOffer;
            this.OfferAtribute = offerAtribute;
            this.Discount = discount;
        }
    }
}
