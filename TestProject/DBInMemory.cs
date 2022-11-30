using System.Collections.Generic;
using TestProject.Entities;

namespace TestProject
{
    public class DBInMemory
    {
        public static ICollection<ReceiptEnitity> Receipts { get; set; } = new List<ReceiptEnitity>();
    }

}
