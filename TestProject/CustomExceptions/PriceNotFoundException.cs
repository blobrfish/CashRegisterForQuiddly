using System;

namespace TestProject.CustomExceptions
{
    /// <summary>
    /// When no price is found for an item
    /// </summary>
    public class PriceNotFoundException : Exception
    {
        public PriceNotFoundException(string itemName)
            : base(string.Format(string.Format("The price for item '{0}' could not be found in the price list", itemName)))
        {
        }
    }
}
