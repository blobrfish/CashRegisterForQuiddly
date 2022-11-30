using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProgrammingTest;
using TestProject.Models;
using TestProject.Concrete;
namespace CashRegisterTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CashRegister MyCashRegister;
        private Double TotalPrice;
        private void BasicArrangements()
        {
                                                              //please make sure to update the paths to the files before running this...
            CashRegister.LoggService = new LoggServiceTxtFile(@"C:\Users\Nizam\source\repos\DeveloperAssignment (1)\DeveloperAssignment\TestProject\logg.txt");
            CashRegister.Settings = new Settings("kr", "kg", "pz");
            this.MyCashRegister = new CashRegister(
                new PriceServiceXml(@"C:\Users\Nizam\source\repos\DeveloperAssignment (1)\DeveloperAssignment\TestProject\prices.xml"),
                new OfferServiceDll(@"C:\Users\Nizam\source\repos\DeveloperAssignment (1)\DeveloperAssignment\TestProject\Offers\OfferTest.dll"),
                new RepositoryDBInMemory());
        }

      



        private void ivTestButton_Click(object sender, EventArgs e)
        {

            this.BasicArrangements();

            //Task1_addItem_count_1();
            //Task1_addItem_count_2();
            //Task1_addItem_weight_1();
            //Task1_addItem_multiple();
            //Task2_line_items_sorted_by_name();
            //Task3_same_items_are_added_together_on_same_line();
            //Task4_prices_from_list_is_applied();
            //Task5_receipt_is_saved_restored();
            //Task5_latest_receipt_is_restored();
            Task6_check_offer_is_applied();
            //Task7_offer_name_is_added();
            //Check_receipt_not_found_exception();
            //Check_price_not_found_exception();
            //Check_receipt_not_found_exception();
            //Check_no_shopping_event_exception();
 

            foreach (string line in MyCashRegister.getReceipt(out this.TotalPrice))
            {
                ivListBox.Items.Add(line);
            }
            ivListBox.Items.Add(string.Format("Sum {0} {1}", TotalPrice, CashRegister.Settings.Currency));

        }



        private void Task1_addItem_count_1()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter");
        }

        private void Task1_addItem_count_2()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 2);
        }

        private void Task1_addItem_weight_1()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Apple, Jonagold", 0.414);
        }

        private void Task1_addItem_multiple()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 2);
            MyCashRegister.addItem("Bread");
            MyCashRegister.addItem("Apple, Jonagold", 0.414);
            MyCashRegister.addItem("Salad", 0.414);
        }

        private void Task2_line_items_sorted_by_name()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 2);
            MyCashRegister.addItem("Bread");
            MyCashRegister.addItem("Apple, Jonagold", 0.414);
            MyCashRegister.addItem("Salad", 0.414);
        }

        private void Task3_same_items_are_added_together_on_same_line()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 2);
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 1);

            MyCashRegister.addItem("Apple, Jonagold", 0.414);
            MyCashRegister.addItem("Apple, Jonagold", 1.0);
        }

        private void Task4_prices_from_list_is_applied()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 2);
            MyCashRegister.addItem("Apple, Jonagold", 0.414);

        }

        private void Task5_receipt_is_saved_restored()
        {
            
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 4);
            MyCashRegister.getReceipt(out TotalPrice);
            MyCashRegister.saveClientReceipt("Arif");
            MyCashRegister.newClient();
            MyCashRegister.addItem("Bread", 4);
            MyCashRegister.getReceipt(out TotalPrice);
            MyCashRegister.saveClientReceipt("Patrik");
            MyCashRegister.restoreClientReceipt("Arif");
        }

        private void Task5_latest_receipt_is_restored()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 4);
            MyCashRegister.saveClientReceipt("Arif");
            MyCashRegister.newClient();
            MyCashRegister.addItem("Bread", 3);
            MyCashRegister.saveClientReceipt("Arif");
            MyCashRegister.restoreClientReceipt("Arif");
        }

        private void Task6_check_offer_is_applied()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 4);
        }

        private void Task7_offer_name_is_added()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 4);
        }

        private void Task8_log_is_added_for_offers()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 4);
        }

        private void Check_price_not_found_exception()
        {
            MyCashRegister.newClient();
            MyCashRegister.addItem("Missing item");
        }

        private void Check_receipt_not_found_exception()
        {
            MyCashRegister.restoreClientReceipt("No receipt Client");
        }

        private void Check_no_shopping_event_exception()
        {
            MyCashRegister.addItem("Milk, Low fat, 1Liter", 4);
        }


    }
}