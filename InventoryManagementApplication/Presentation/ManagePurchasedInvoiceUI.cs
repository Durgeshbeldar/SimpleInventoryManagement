using InventoryManagementApplication.Controllers;
using InventoryManagementApplication.Interfaces;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Presentation
{
    internal class ManagePurchasedInvoiceUI
    {
        public static PurchasedInvoiceController purchaseController = new PurchasedInvoiceController();
        public static void ManagePurchasedInvoices()
        {
            while (true)
            {
                DisplayMainMenu();
                int choice = UserInputs.GetUserChoice(1, 6);
                switch (choice)
                {
                    case 1:
                        AddPurchasedInvoice();
                        break;
                    case 2:
                        GetInvoiceById();
                        break;
                    case 3:
                        GetInvoiceByDate();
                        break;
                    case 4:
                        GetAllInvoices();
                        break;
                    case 5:
                        DeleteInvoiceById();
                        break;
                    case 6:
                        Console.WriteLine("Returning To Main Menu...");
                        return;   
                }
            }
        }

     
        static void DeleteInvoiceById()
        {
            int userInput = UserInputs.GetValidIntegerValue("Purchased Invoice Id");

            if (purchaseController.DeletePurchasedInvoice(userInput))
            {
                Console.WriteLine("Invoice Deleted Successfully...!");
                return ;
            }
            Console.WriteLine("Invoice Not Found Please Enter Valid Invoice Id");
        }
        static void GetInvoiceByDate()
        {
            DateTime date = UserInputs.GetValidDate();
            List<PurchasedInvoice> invoices = purchaseController.GetInvoicesByDate(date);
            if (invoices != null)
            {
                DisplayInvoicesSummary(invoices);
                return;
            }
            Console.WriteLine("No Invoices Found with Given Date :(");
        }
        static void GetAllInvoices()
        {
            List<PurchasedInvoice> purchasedInvoices = purchaseController.GetAllPurchasedInvoices();
            DisplayInvoicesSummary(purchasedInvoices);
        }
        static void DisplayInvoicesSummary(List<PurchasedInvoice> invoices)
        {
            if (invoices == null)
            {
                Console.WriteLine("No Invoices Found :(");
                return;
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"Invoice ID",-15}{"Wholesaler Name",-25}{"Wholesaler ID",-15}{"Total Price",-15}{"Date",-15}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (var invoice in invoices)
            {
                string invoiceDate = invoice.InvoiceDate.ToString("dd-MM-yyyy");
                Console.WriteLine($"{invoice.InvoiceId,-15}{invoice.Wholesaler.Name,-25}{invoice.WholesalerId,-15}{invoice.TotalAmount,-15}{invoiceDate,-15}");
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
        }

        static string PrintInvoice(PurchasedInvoice invoice)
        {
            List<PurchasedItem> LineItems = invoice.PurchasedItems;
            int invoiceId = invoice.InvoiceId;
            DateTime invoiceDate = invoice.InvoiceDate; 
            Wholesaler wholesaler = invoice.Wholesaler;
            double totalAmount = invoice.TotalAmount;

            StringBuilder invoiceBuilder = new StringBuilder();

            invoiceBuilder.AppendLine("********************** PURCHASED INVOICE **********************");
            invoiceBuilder.AppendLine($"Invoice ID: {invoiceId}".PadRight(50));
            invoiceBuilder.AppendLine($"Date: {invoiceDate.ToString("dd-MM-yyyy")}".PadRight(50));
            invoiceBuilder.AppendLine($"Wholesaler: {wholesaler.Name}".PadRight(50));
            invoiceBuilder.AppendLine("--------------------------------------------------------");
            invoiceBuilder.AppendLine("Product Name".PadRight(25) + "Quantity".PadRight(15) + "Price".PadLeft(10));
            invoiceBuilder.AppendLine("--------------------------------------------------------");

            foreach (var item in LineItems)
            {
                var product = item.Product; 
                invoiceBuilder.AppendLine($"{product.Name.PadRight(25)}{item.Quantity.ToString().PadRight(15)}{item.TotalPrice.ToString("F2").PadLeft(11)}");
            }

            invoiceBuilder.AppendLine("--------------------------------------------------------");
            invoiceBuilder.AppendLine($"Total Amount: {totalAmount.ToString("F2").PadLeft(37)}");
            invoiceBuilder.AppendLine("***************************************************************");

            return invoiceBuilder.ToString();
        }

        static void GetInvoiceById()
        {
            int userInput = UserInputs.GetValidIntegerValue("Purchased Invoice Id");
            PurchasedInvoice invoice =  purchaseController.GetPurchasedInvoiceById(userInput);
            if(invoice == null)
            {
                Console.WriteLine("Purchased Invoice Details Not Found, Please Enter Valid Invoice Id");
                return;
            }
            Console.WriteLine($"Purchased Invoice Details Found:\n{PrintInvoice(invoice)}\n");
           

        }
        static void AddPurchasedInvoice()
        {
            try
            {
                Console.WriteLine("\nSelect Wholesaler From Following List :");
                List<Wholesaler> wholesalers = purchaseController.GetAllWholesalers();
                int count = 0;
                wholesalers.ForEach(wholesaler => Console.WriteLine($"{++count}. {wholesaler.Name}"));
                int userChoice = UserInputs.GetUserChoice(1, wholesalers.Count);
                int wholesalerId = wholesalers[userChoice - 1].WholesalerId;

                PurchasedInvoice emptyPurchasedInvoice = new PurchasedInvoice(wholesalerId);
                int invoiceId = purchaseController.AddPurchasedInvoice(emptyPurchasedInvoice);

                List<PurchasedItem> purchasedItems = SelectProducts(invoiceId);
                AddPurchasedItems(purchasedItems);

                PurchasedInvoice purchasedInvoice = new PurchasedInvoice(invoiceId, wholesalerId, purchasedItems);
                List<Tuple<int, int>> productWithQuantities = new List<Tuple<int, int>>();
                purchasedItems.ForEach(item =>
                {
                    int productId = item.ProductId;
                    int quantities = item.Quantity;
                    productWithQuantities.Add(Tuple.Create(productId, quantities));
                });
                purchaseController.UpdateInvoice(purchasedInvoice);
                string result = purchaseController.AddStocks(productWithQuantities);
                Console.WriteLine("\n" + result + "\nInvoice Is Saved To The Database & Stocks Are Updated Successfully");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);     
            }
        }

        static void AddPurchasedItems(List<PurchasedItem> purchasedItems)
        {
            purchasedItems.ForEach(item =>
            {
                purchaseController.AddPurchasedItem(item);
            });
        }

        static List<PurchasedItem> SelectProducts(int invoiceId)
        {
            List<Product> products = purchaseController.GetAllProducts();
            List<PurchasedItem> purchasedProducts = new List<PurchasedItem>();

            // This loop continuously run till user dont wanted to add more products.

            do
            {
                PurchasedItem purchasedItem;
          
                if (purchasedProducts.Count == 0)
                {   
                    purchasedItem = GetProductToAdd(products);
                    purchasedItem.InvoiceId = invoiceId;

                    purchasedProducts.Add(purchasedItem);
                    Console.WriteLine("Product Added Successfully\n");
                    PrintAddedProducts(purchasedProducts);
                    continue;
                }
                Console.WriteLine("Do you want to add More Products to Invoice Choose 1 For Yes and 2 For No:");
                int userChoice = UserInputs.GetOneOrTwo();
                if (userChoice == 2)
                    return purchasedProducts;

                purchasedItem = GetProductToAdd(products);
                purchasedItem.InvoiceId = invoiceId; // Setting The Foreign Key 

                purchasedProducts.Add(purchasedItem);

                Console.WriteLine("Product Added Successfully\n");
                PrintAddedProducts(purchasedProducts);
            } while(true);
        }

        static PurchasedItem GetProductToAdd(List <Product> products)
        {
            int count = 0;
            Console.WriteLine("Select Product From the Follwoing List :\n" +
                      "Note : If Product Not Found in Following List Then Please Add New Product.");
            products.ForEach(product => Console.WriteLine($"{++count}. {product.Name}"));
            int Choice = UserInputs.GetUserChoice(1, products.Count);
            Product product = products[Choice - 1];
            Console.WriteLine("Enter The Quantity : ");
            int quantity = int.Parse(Console.ReadLine());
            double totalPrice = product.PurchasedPrice * quantity;
            return new PurchasedItem(product.ProductId, quantity, totalPrice);
        }
        static void PrintAddedProducts(List<PurchasedItem> purchasedProducts)
        {
            int count = 0;
            Console.WriteLine("Added Products");
            purchasedProducts.ForEach(item =>
            {
                Product product =  purchaseController.GetProductById(item.ProductId);
                Console.WriteLine($"\n{++count}. Name : {product.Name}\n" +
                $"Quantity : {item.Quantity}");
            });
        }
        
        
        static void DisplayMainMenu()
        {
            Console.WriteLine($"\nWhat Do You Wish to Do?\n" +
                $"1.  Create OR Add New Purchased Invoice\n" +
                $"2.  Get Invoice By Id \n" +
                $"3.  Get Invoice By Date\n" +
                $"4.  Get All Purchased Invoices\n" +
                $"5.  Delete Purchased Invoice\n" +
                $"6.  Back To Main Menu\n");

            // We can add more CRUD here but for now I kept it Simple           
        }
    }
}
