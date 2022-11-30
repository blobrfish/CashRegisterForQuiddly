namespace TestProject.Interfaces
{
    public interface ILoggService
    {
        /// <summary>
        /// Adds an entry for an applied offer
        /// </summary>
        /// <param name="piName">Name of the item</param>
        /// <param name="quantity">Quantity of the item</param>
        /// <param name="offerName">Attribute of the offer</param> 
        /// <param name="additionalDetails">Additional details, optional</param> 
        void AddOfferEntry(string itemName, string quantity,  string offerName, string additionalDetails = null);
    }
}
