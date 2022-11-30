using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingTest
{
    #region Task 1
    // Implement the ICashRegister interface below
    // All items should have the fixed price 10 per unit or 10 per Kg.
    public interface ICashRegister
    {
        /// <summary>
        /// Start a new empty shopping event (empty receipt)
        /// </summary>
        void newClient();

        /// <summary>
        /// Add a item (fixed price) to the receipt
        /// </summary>
        /// <param name="piName">Name of the item, used to recognize it and find its price</param>
        /// <example>addItem("Milk, Low fat, 1Liter");</example>
        void addItem(string piName);

        /// <summary>
        /// Add a number of items (fixed price) to the receipt
        /// </summary>
        /// <param name="piName">Name of the item, used to recognize it and find its price</param>
        /// <example>addItem("Milk, Low fat, 1Liter", 4);</example>
        void addItem(string piName, int piCount);

        /// <summary>
        /// Add a item/items to the receipt, where the price is proportional to its weight
        /// </summary>
        /// <param name="piName">Name of the item, used to recognize it and find its price</param>
        /// <example>addItem("Apple, Jonagold", 0.414);</example>
        void addItem(string piName, double piWeight);

        /// <summary>
        /// Returns a well formated list of strings, with all items, their price and the total cost.
        /// The total cost is also returned in the poTotalPrice parameter
        /// </summary>
        /// <param name="poTotalPrice">Total price</param>
        /// <returns>List of strings, which forms the receipt</returns>
        /// <example>
        /// newClient();
        /// addItem("Milk, Low fat, 1Liter", 4);
        /// addItem("Apple, Jonagold", 0.414);
        /// double sum;
        /// getReceipt(out sum); 
        /// Will give something like:
        /// "Milk, Low fat, 1Liter, (10.00 each) 4 pz           40.00"
        /// "Apple, Jonagold, (10.00 kr/kg) 0.414 kg             4.14"
        /// "Sum                                                44.14"
        /// </example>
        List<string> getReceipt(out double poTotalPrice);

    }
    #endregion

    #region Task 2
    // Change the implementation so that the items on the receipt are sorted by their name.
    #endregion

    #region Task 3
    // Change the implementation so that items are added toghether. 
    // That is: adding 1 milk 3 times should give the same result as adding 3 milk one time.
    #endregion

    #region Task 4
    // Fetch prices from the file "prices.xml" (attached) instead of hardcoded values
    #endregion

    #region Task 5
    // Change interface on your implementation from ICashRegister to ICachRegisterDeluxe
    // Implement the extra methods
    public interface ICachRegisterDeluxe : ICashRegister
    {
        /// <summary>
        /// Save the current receipt, with a client name.
        /// No limit in number of receipt saved but if the name already exist old receipt
        /// will be lost
        /// </summary>
        /// <param name="piClientName">Name to save receipt under</param>
        void saveClientReceipt(string piClientName);

        /// <summary>
        /// Restore the previous saved receipt.
        /// </summary>
        /// <param name="piClientName">Name previous used to save the receipt under</param>
        void restoreClientReceipt(string piClientName);
    }
    #endregion

    #region Task 6
    // IOffer is an interface for checking if there is an offer on a item.
    // Modify your implementation so that it checks for offers and adds discount to the receipt 
    // before returning it (in getReceipt) in the following manner:
    // Write code that dynamicly loads all dll:s from offer subdirectory below the current directory
    // In each loaded dll, look for classes implementing IOffer
    // Go through every item and test if its valid for discount, if so add a discount row under the
    // item row in the receipt. checkForOffer will return a positiv discount but it should be 
    // presented negative on the receipt 
    // You can used attached dll OfferTest.dll to test your code.
    // Example:
    // "Milk, Low fat, 1Liter, (7.50 each) 4 pz            30.00"
    // "Discount                                           -7.50"
    // "Apple, Jonagold, (19.50 kr/kg) 0.414 kg             8.40"
    // "Sum                                                30.90"
    public interface IOffer
    {
        /// <summary>
        /// Checks if there is an offer on the named item and for the number of items.
        /// Offer may depend on number of items bought
        /// </summary>
        /// <param name="piName">Name of item</param>
        /// <param name="piCount">Number of items the customer has purchased</param>
        /// <param name="piDiscount">Out parameter, returning the discount. Result only valid if method returns true</param>
        /// <param name="piPrize">Prize of the item, per unit</param>
        /// <returns>true if a valid offer is found, otherwise false</returns>
        bool checkForOffer(string piName, int piCount, double piPrize, out double poDiscount);

        /// <summary>
        /// Checks if there is an offer on the named item and for the weight of items.
        /// Offer may depend on how much items bought (weight)
        /// </summary>
        /// <param name="piName">Name of item</param>
        /// <param name="piWeight">Weight of the item/items bought</param>
        /// <param name="piDiscount">Out parameter, returning the discount. Result only valid if method returns true</param>
        /// <param name="piPrize">Prize of the item, per Kg</param>
        /// <returns>true if a valid offer is found, otherwise false</returns>
        bool checkForOffer(string piName, double piWeight, double piPrize, out double poDiscount);
    }
    #endregion

    #region Task 7
    // Each offer has a name that should be presented on the discount row on the receipt
    // The name of the offer can be found in the attribute connected to the class implementing IOffer
    // The attribute is of OfferAttribute type
    // Example:
    // "Milk, Low fat, 1Liter, (7.50 each) 4 pz            30.00"
    // "Discount Buy 4 for prize of 3                      -7.50"
    // "Apple, Jonagold, (19.50 kr/kg) 0.414 kg             8.40"
    // "Sum                                                30.90"

    [AttributeUsage(AttributeTargets.Class)]
    public class OfferAttribute : Attribute
    {
        private string ivOfferName;

        public string OfferName
        {
            get { return ivOfferName; }
            set { ivOfferName = value; }
        }
    }
    #endregion

    #region Task 8
    // Add logging when a valid offer is found.
    // Logg the following to a textfile "logg.txt":
    // Date, Item, Item count or weight, OfferName, Public properties in Offer-class.
    #endregion
}
