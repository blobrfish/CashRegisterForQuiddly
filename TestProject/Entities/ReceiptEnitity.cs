using System.Collections.Generic;

namespace TestProject.Entities
{
    /// <summary>
    /// Represents a receipt record
    /// </summary>
    public class ReceiptEnitity
    {
        public string ClientName { get; set; }
        public IEnumerable<ReceiptLineItemEntity> LineItems { get; set; }
    }
}
