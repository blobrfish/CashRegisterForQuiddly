using System.Collections.Generic;
using ProgrammingTest;
using TestProject.Interfaces;
using TestProject.CustomExceptions;

namespace TestProject.Models
{

    public class CashRegister : ICachRegisterDeluxe
    {
        private ShoppingEvent ShoppingEvent;
        private IPriceService PriceService;
        private IOfferService OfferService;
        public static ILoggService LoggService;
        private IReceiptRepository ReceiptRepository;
        public static Settings Settings;

        public CashRegister(IPriceService priceService, IOfferService offerService, IReceiptRepository receiptRepository)
        {
            this.PriceService = priceService;
            this.OfferService = offerService;
            this.ReceiptRepository = receiptRepository;
            this.CheckIfCriticalDependenciesAreFound();
            this.LoadServices();
        }
        private bool IsShoppingEventStarted => this.ShoppingEvent != null;
        public void addItem(string itemName) 
            => this.addItem(itemName, Settings.MinimumPurchaseCount); 
           
        public void addItem(string itemName, int count) 
            => this.addItemToShoppingEvent(new ShoppingEventItem(itemName, count, this.PriceService.GetPrice(itemName, true)));

        private void addItemToShoppingEvent(ShoppingEventItem item)
        {
            if (!this.IsShoppingEventStarted)
                throw new NoShoppingEventStartedException();
            this.ShoppingEvent.AddItem(item);
        }
        public void addItem(string itemName, double weight) 
            =>this.addItemToShoppingEvent(new ShoppingEventItem(itemName, weight, this.PriceService.GetPrice(itemName,false)));

        public List<string> getReceipt(out double poTotalPrice)
        {
            if(!this.IsShoppingEventStarted)
                throw new NoShoppingEventStartedException();
            
            this.ShoppingEvent.ApplyOffers(this.OfferService);
            poTotalPrice = this.ShoppingEvent.TotalPrice;
            return ShoppingEvent.ReceiptLineItems;
        }

        public void newClient() 
            =>this.ShoppingEvent = ShoppingEvent.CreateNewShoppingEvent();

        public void restoreClientReceipt(string clientName)
        {
            var restoredReceipt = this.ReceiptRepository.Get(clientName);
            if(restoredReceipt == null)
                throw new ReceiptNotFoundException();
           
            this.ShoppingEvent = ShoppingEvent.RestoreShoppingEvent(restoredReceipt);
        }

        public void saveClientReceipt(string clientName)
        {
            var previousReceiptOfThisClient =  this.ReceiptRepository.Get(clientName);

            if (previousReceiptOfThisClient != null )
                this.ReceiptRepository.Delete(previousReceiptOfThisClient);
  
            this.ReceiptRepository.Save(this.ShoppingEvent.GetReceiptEntity(clientName)); 
        }

        private void LoadServices()
        {
            this.PriceService.LoadPrices();
            this.OfferService.LoadOffers();
        }

        private void CheckIfCriticalDependenciesAreFound()
        {
            if (this.PriceService == null)
                throw new DependencyNotFoundException("price service");
            if (this.OfferService == null)
                throw new DependencyNotFoundException("offer service");
            if (this.ReceiptRepository == null)
                throw new DependencyNotFoundException("receipt repository");
            if (CashRegister.Settings == null)
                throw new DependencyNotFoundException("settings");
        }
    }
}
