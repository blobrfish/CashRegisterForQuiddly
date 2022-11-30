using System.Collections.Generic;
using System.Linq;
using TestProject.Entities;
using TestProject.Interfaces;

namespace TestProject.Models
{
    public class ShoppingEvent
    {
        private ShoppingEvent()
        {}
        public static ShoppingEvent CreateNewShoppingEvent() => new ShoppingEvent();
        private ShoppingEvent(ReceiptEnitity receipt)
          => this.Items = receipt.LineItems.Select(l => new ShoppingEventItem(l.Name, l.Quantity, l.PricePerQuanity, l.IsQuantityCount, l.Discount)).ToList();

        public static ShoppingEvent RestoreShoppingEvent(ReceiptEnitity receipt) => new ShoppingEvent(receipt);

        private List<ShoppingEventItem> Items = new List<ShoppingEventItem>();

        public void AddItem(ShoppingEventItem item)
        {
            var addedItem = GetAddedItem(item);

            if(!IsItemAlreadyAdded(addedItem))
                this.Items.Add(item);
            else
                addedItem.UpdateQuantity(item);
        }

        private bool IsItemAlreadyAdded(ShoppingEventItem item) => item != null; 
        private ShoppingEventItem GetAddedItem(ShoppingEventItem item) => this.Items.FirstOrDefault(a => a.IsSameItem(item));

        public double TotalPrice => this.Items.Sum(i => i.TotalPrice);

        public ReceiptEnitity GetReceiptEntity(string clientName) => new ReceiptEnitity { ClientName = clientName, 
            LineItems = this.Items.Select(i => i.ReceiptLineEntity)
        };

        public List<string> ReceiptLineItems => this.Items.OrderBy(i => i.Name).Select(i => i.ReceiptLineItem).ToList();
        public void ApplyOffers(IOfferService offerService)
        {
            foreach (var addedItem in Items)
                addedItem.ApplyOffer(offerService);
        }
    }
}

