using System;

namespace TestProject.CustomExceptions
{
    /// <summary>
    /// When no receipt is found for an client
    /// </summary>
    public class ReceiptNotFoundException : Exception
    {
        public ReceiptNotFoundException()
            : base(string.Format("No receipt was found for this client"))
        {
        }
    }
}
