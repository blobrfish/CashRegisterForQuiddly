namespace TestProject.Entities
{
    /// <summary>
    /// Represents a receipt line item record
    /// </summary>
    public class ReceiptLineItemEntity
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public bool IsQuantityCount { get; set; }
        public double PricePerQuanity { get; set; }
        public double Discount { get; set; }
    }

}
