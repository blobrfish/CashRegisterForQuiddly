namespace TestProject.Interfaces
{
    public interface IPriceService
    {
        /// <summary>
        /// Loads prices. Must be called before service can be used
        /// </summary>
        void LoadPrices();

        /// <summary>
        /// Gets the price of an item that is quantified per pz
        /// </summary>
        /// <param name="itemName">Name of the item</param>
        /// <param name="isQuantityCount">True if quantity is count, false if weight</param>

        double GetPrice(string itemName, bool isQuantityCount);

    }

    
}
