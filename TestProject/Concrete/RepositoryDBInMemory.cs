using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ProgrammingTest;
using TestProject.Interfaces;
using TestProject;
using TestProject.Entities;
namespace TestProject.Concrete
{
    /// <summary>
    /// A repository that reads and writes to a db in memory
    /// </summary>
    public class RepositoryDBInMemory : IReceiptRepository
    {
        public void Delete(ReceiptEnitity receipt) => DBInMemory.Receipts.Remove(receipt);
        public ReceiptEnitity Get(string clientName) => DBInMemory.Receipts.Where(r => clientName.Equals(r.ClientName,StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        public void Save(ReceiptEnitity receipt) => DBInMemory.Receipts.Add(receipt);
    }
}
