using TestProject.Entities;

namespace TestProject.Interfaces
{
    public interface IReceiptRepository
    {
        /// <summary>
        /// Saves a receipt
        /// </summary>
        /// <param name="receipt">The receipt to be saved</param>
        void Save(ReceiptEnitity receipt);

        /// <summary>
        /// Retrives a receipt
        /// </summary>
        /// <param name="clientName">Name of the client</param>
        ReceiptEnitity Get(string clientName);

        /// <summary>
        /// Deletes a receipt
        /// </summary>
        /// <param name="receipt">The receipt to be deleted</param>
        void Delete(ReceiptEnitity receipt);
      
    }

}
