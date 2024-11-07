using InventoryManagementApplication.Controllers;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Presentation
{
    internal class ManageCustomerUI
    {
        static CustomerController customerController = new CustomerController();
        public static void ManageCustomers()
        {
            while (true)
            {
                DisplayMenu();
                int choice = UserInputs.GetUserChoice(1, 6);
                switch (choice)
                {
                    case 1:
                        AddNewCustomer(); 
                        break;
                    case 2:
                        UpdateCustomer(); 
                        break;
                    case 3:
                        DeleteCustomer(); 
                        break;
                    case 4:
                        ViewAllCustomers();
                        break;
                    case 5:
                        SearchCustomer();  
                        break;
                    case 6:
                        Console.WriteLine("Returned To Main Menu");
                        return; 
                }
            }
        }

        static void AddNewCustomer()
        {
            try
            {
                Console.WriteLine("Enter Customer Details :");

                // Directly take string inputs
                Console.WriteLine("Enter Customer Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Customer Contact Number :");
                string contactNumber = Console.ReadLine();

                Console.WriteLine("Enter Customer Address: ");
                string address = Console.ReadLine();

                Customer customer = new Customer()
                {
                    Name = name,
                    ContactNumber = contactNumber,
                    Address = address
                };

                string result = customerController.AddCustomer(customer);  
                Console.WriteLine(result); 

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void UpdateCustomer()
        {
            try
            {
                int customerId = UserInputs.GetValidIntegerValue("Customer ID");
                Console.WriteLine("Enter New Details for Customer: ");


                Console.WriteLine("Enter Customer Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Customer Contact Number :");
                string contactNumber = Console.ReadLine();

                Console.WriteLine("Enter Customer Address: ");
                string address = Console.ReadLine();

                Customer customer = new Customer()
                {
                    CustomerId = customerId,
                    Name = name,
                    ContactNumber = contactNumber,
                    Address = address
                };

                string result = customerController.UpdateCustomer(customer);
                Console.WriteLine(result);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DeleteCustomer()
        {
            try
            {
                int customerId = UserInputs.GetValidIntegerValue("Customer ID");

                string result = customerController.DeleteCustomer(customerId);
                Console.WriteLine(result);
            }catch( Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ViewAllCustomers()
        {
            try
            {
                var customers = customerController.GetAllCustomers();
                if (customers == null)
                    throw new Exception("Customers Not Found Try Again...");
                Console.WriteLine($"\nTotal Customers : {customers.Count}\n");
                customers.ForEach(customer => Console.WriteLine(customer) );

            }catch( Exception ex) 
            {
                Console.WriteLine( ex.Message);
            }
        }

        static void SearchCustomer()
        {
            int customerId = UserInputs.GetValidIntegerValue("Customer ID");

            var customer = customerController.GetCustomerByUsername(customerId); 
            try
            {
                if (customer != null)
                {
                    Console.WriteLine("Customer Found :\n" +
                        "" + customer);
                    return;
                }
                throw new Exception("Customer Not Found ...!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message +"\n");
            }
        }




        public static void DisplayMenu()
        {
            Console.WriteLine("\nWhat would you like to do under Customer Management?\n" +
                              "1. Add New Customer\n" +
                              "2. Update Customer Details\n" +
                              "3. Delete Customer\n" +
                              "4. View All Customers\n" +
                              "5. Search Customer By Id\n" +
                              "6. Back to Main Menu\n");
        }
    }
}
