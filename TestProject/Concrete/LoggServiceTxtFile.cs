using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logs entries to a local txt file 
    /// </summary>
    public class LoggServiceTxtFile : ResourceServiceBase, ILoggService
    {
        public LoggServiceTxtFile(string filePath) : base(filePath, "logg txt file",false)
        { }
        public void AddOfferEntry(string itemName, string quantity, string offer, string additionalDetails = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nDate:" + DateTime.Now);
            sb.Append(" Name:" + itemName);
            sb.Append(" Quantity:" + quantity);
            sb.Append(" Offer:" + offer);
            sb.Append( " Additional details: " + additionalDetails != null ? additionalDetails : "None"  );
            File.AppendAllText(this.Path, sb.ToString());
            sb.Clear();

        }
    }
}
