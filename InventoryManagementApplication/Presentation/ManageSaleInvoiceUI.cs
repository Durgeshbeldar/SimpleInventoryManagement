using InventoryManagementApplication.Controllers;
using InventoryManagementApplication.Interfaces;
using InventoryManagementApplication.Models;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;

namespace InventoryManagementApplication.Presentation
{
    internal class ManageSaleInvoiceUI
    {
        public static SaleInvoiceController saleController = new SaleInvoiceController();

        public static void ManageSaleInvoices()
        {
            while (true)
            {
                DisplayMainMenu();
                int choice = UserInputs.GetUserChoice(1, 6);
                switch (choice)
                {
                    case 1:
                        AddSalesInvoice();
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
            int userInput = UserInputs.GetValidIntegerValue("Sales Invoice Id");

            if (saleController.DeleteSalesInvoice(userInput))
            {
                Console.WriteLine("Invoice Deleted Successfully...!");
                return;
            }
            Console.WriteLine("Invoice Not Found, Please Enter Valid Invoice Id");
        }

        static void GetInvoiceByDate()
        {
            DateTime date = UserInputs.GetValidDate();
            List<SaleInvoice> invoices = saleController.GetSalesInvoicesByDate(date);
            if (invoices != null)
            {
                DisplayInvoicesSummary(invoices);
                return;
            }
            Console.WriteLine("No Invoices Found with Given Date :(");
        }

        static void GetAllInvoices()
        {
            List<SaleInvoice> salesInvoices = saleController.GetAllSalesInvoices();
            DisplayInvoicesSummary(salesInvoices);
        }

        static void DisplayInvoicesSummary(List<SaleInvoice> invoices)
        {
            if (invoices == null)
            {
                Console.WriteLine("No Invoices Found :(");
                return;
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"Invoice ID",-15}{"Customer Name",-25}{"Customer ID",-15}{"Total Price",-15}{"Date",-15}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (var invoice in invoices)
            {
                string invoiceDate = invoice.InvoiceDate.ToString("dd-MM-yyyy");
                Console.WriteLine($"{invoice.InvoiceId,-15}{invoice.Customer.Name,-25}{invoice.CustomerId,-15}{invoice.TotalAmount,-15}{invoiceDate,-15}");
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
        }

        static void GetInvoiceById()
        {
            int userInput = UserInputs.GetValidIntegerValue("Sales Invoice Id");
            SaleInvoice invoice = saleController.GetSalesInvoiceById(userInput);
            if (invoice == null)
            {
                Console.WriteLine("Sales Invoice Details Not Found, Please Enter Valid Invoice Id");
                return;
            }
            Console.WriteLine($"Sales Invoice Details Found:\n{invoice}\n");
        }

        static void AddSalesInvoice()
        {
            try
            {
                Console.WriteLine("\nSelect Customer From Following List:");
                List<Customer> customers = saleController.GetAllCustomers();
                int count = 0;
                customers.ForEach(customer => Console.WriteLine($"{++count}. {customer.Name}"));
                int userChoice = UserInputs.GetUserChoice(1, customers.Count);
                int customerId = customers[userChoice - 1].CustomerId;
                List<SaleItem> saleItems = SelectProducts();
                SaleInvoice saleInvoice = new SaleInvoice(customerId, saleItems);
                List<Tuple<int, int>> productWithQuantities = new List<Tuple<int, int>>();
                saleItems.ForEach(item =>
                {
                    int productId = item.Product.ProductId;
                    int quantities = item.Quantity;
                    productWithQuantities.Add(Tuple.Create(productId, quantities));
                });
                saleController.AddSalesInvoice(saleInvoice);
                string result = saleController.RemoveStocks(productWithQuantities);
                Console.WriteLine("\n" + result + "\nInvoice Is Saved To The Database & Stocks Are Updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static List<SaleItem> SelectProducts()
        {
            List<SaleItem> saleItems = new List<SaleItem>();
            do
            {
                SaleItem saleItem;
                List<Product> products = saleController.GetAllProducts();
                if (saleItems.Count == 0)
                {
                    saleItem = GetProductToAdd(products);
                    saleItems.Add(saleItem);
                    Console.WriteLine("Product Added Successfully:");
                    PrintAddedProducts(saleItems);
                    continue;
                }
                Console.WriteLine("Do you want to add More Products to Invoice? Choose 1 For Yes and 2 For No:");
                int userChoice = UserInputs.GetOneOrTwo();
                if (userChoice == 2)
                    return saleItems;

                saleItem = GetProductToAdd(products);
                saleItems.Add(saleItem);
                Console.WriteLine("Product Added Successfully:");
                PrintAddedProducts(saleItems);
            } while (true);
        }

        static SaleItem GetProductToAdd(List<Product> products)
        {
            int count = 0;
            Console.WriteLine("Select Product From the Following List:\n" +
                      "Note: If Product Not Found in Following List Then Please Add New Product.");
            products.ForEach(product => Console.WriteLine($"{++count}. {product.Name}"));
            try
            {
                int choice = UserInputs.GetUserChoice(1, products.Count);
                Console.WriteLine("Enter The Quantity:");
                int quantity = int.Parse(Console.ReadLine());
                if (saleController.IsAvailable(products[choice - 1].ProductId, quantity))
                {
                    Product product = saleController.GetProductById(products[choice - 1].ProductId);
                    return new SaleItem(product, quantity);
                }
                Console.WriteLine("Product is Not Available In Stock, Please Try Another Product to Add");
                return GetProductToAdd(products);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetProductToAdd(products);
            }
        }

        static void PrintAddedProducts(List<SaleItem> saleItems)
        {
            int count = 0;
            Console.WriteLine("Added Products:");
            saleItems.ForEach(item => Console.WriteLine($"\n{++count}. Name: {item.Product.Name}\n" +
                $"Quantity: {item.Quantity}"));
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine($"\nWhat Do You Wish to Do?\n" +
                $"1.  Create OR Add New Sales Invoice\n" +
                $"2.  Get Invoice By Id \n" +
                $"3.  Get Invoice By Date\n" +
                $"4.  Get All Sales Invoices\n" +
                $"5.  Delete Sales Invoice\n" +
                $"6.  Back To Main Menu\n");

            // More CRUD operations can be added if needed
        }
    }
}
