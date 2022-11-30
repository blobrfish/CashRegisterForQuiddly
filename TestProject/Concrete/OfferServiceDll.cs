using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ProgrammingTest;
using TestProject.Interfaces;
using TestProject.BaseTypes;
namespace TestProject.Concrete
{

    /// <summary>
    /// Gets offers from local dll files 
    /// </summary>
    public class OfferServiceDll : ResourceServiceBase, IOfferService
    {

        private IEnumerable<Type> Types; 
        private List<IOffer> offers = new List<IOffer>();
        public OfferServiceDll(string path) : base(path, "offers", true)
        {}

        public CheckOfferResult CheckForOffer(string itemName, double quantity, double pricePerQuantity, bool isQuantityCount)
        {
            bool hasOffer = false;
            double discount = 0;
            string offerName = null;

            foreach (var offer in offers)
            {
                hasOffer = isQuantityCount ? offer.checkForOffer(itemName, (int)quantity, pricePerQuantity, out discount) :
                   offer.checkForOffer(itemName, pricePerQuantity, pricePerQuantity, out discount);
                if (hasOffer)
                    offerName = offer.GetType().GetCustomAttributes(typeof(OfferAttribute), true)?.Cast<OfferAttribute>().First().OfferName;
            }
            return new CheckOfferResult(hasOffer, offerName, discount);
        }

        
        public void LoadOffers()
        {
            this.Types = Assembly.LoadFile(this.Path).GetTypes();

            foreach (Type type in this.Types)            
                offers.Add((IOffer)Activator.CreateInstance(type));
      
        }

        public string AdditionalDetailsForLogging
        {
            get
            {
                var type = this.Types.Where(t => t.IsClass).FirstOrDefault(t => t.Name == "Offer");

                if (type == null)
                    return string.Empty;

                return string.Join(" ", type.GetProperties(BindingFlags.Public).Select(p => p.Name));
            }
        }
    }
}
