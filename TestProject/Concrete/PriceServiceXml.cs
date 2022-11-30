using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ProgrammingTest;
using TestProject.Interfaces;
using TestProject.BaseTypes;
using TestProject.CustomExceptions;
namespace TestProject.Concrete
{

    /// <summary>
    /// Gets prices from local xml document 
    /// </summary>
    public class PriceServiceXml : ResourceServiceBase, IPriceService
    {
        private XmlDocument Doc = new XmlDocument();
        public void LoadPrices() => Doc.Load(this.Path);
        public PriceServiceXml(string docPath) : base(docPath, "price list", true) { }
        private double GetPrice(string itemName, string nodeSection)
        {
            var node = (Doc.DocumentElement.SelectSingleNode(string.Format("//Prices/{0}/Item[@Name = '{1}']", nodeSection, itemName)));

            if (node == null)
                throw new PriceNotFoundException(itemName);

            return Convert.ToDouble(node.InnerText.Replace('.', ','));
        }

        public double GetPrice(string piName, bool isQuantityCount) => isQuantityCount ? GetPrice(piName, "PricePerItem") : GetPrice(piName, "PricePerKg");

    }
}
