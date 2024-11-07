using InventoryManagementApplication.Controllers;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Presentation
{
    internal class ManageWholesalerUI
    {
        static WholesalerController wholesalerController = new WholesalerController();

        public static void ManageWholesalers()
        {
            while (true)
            {
                DisplayMenu();
                int choice = UserInputs.GetUserChoice(1, 6);
                switch (choice)
                {
                    case 1:
                        AddNewWholesaler();
                        break;
                    case 2:
                        UpdateWholesaler();
                        break;
                    case 3:
                        DeleteWholesaler();
                        break;
                    case 4:
                        ViewAllWholesalers();
                        break;
                    case 5:
                        SearchWholesaler();
                        break;
                    case 6:
                        Console.WriteLine("Returned To Main Menu");
                        return;
                }
            }
        }

        static void AddNewWholesaler()
        {
            try
            {
                Console.WriteLine("Enter Wholesaler Details :");

                Console.WriteLine("Enter Wholesaler Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Wholesaler Contact Number :");
                string contactNumber = Console.ReadLine();

                Console.WriteLine("Enter Wholesaler Address: ");
                string address = Console.ReadLine();

                Wholesaler wholesaler = new Wholesaler()
                {
                    Name = name,
                    ContactNumber = contactNumber,
                    Address = address
                };

                string result = wholesalerController.AddWholesaler(wholesaler);
                Console.WriteLine(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void UpdateWholesaler()
        {
            try
            {
                int wholesalerId = UserInputs.GetValidIntegerValue("Wholesaler ID");
                Console.WriteLine("Enter New Details for Wholesaler: ");

                Console.WriteLine("Enter Wholesaler Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Wholesaler Contact Number :");
                string contactNumber = Console.ReadLine();

                Console.WriteLine("Enter Wholesaler Address: ");
                string address = Console.ReadLine();

                Wholesaler wholesaler = new Wholesaler()
                {
                    WholesalerId = wholesalerId,
                    Name = name,
                    ContactNumber = contactNumber,
                    Address = address
                };

                string result = wholesalerController.UpdateWholesaler(wholesaler);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DeleteWholesaler()
        {
            try
            {
                int wholesalerId = UserInputs.GetValidIntegerValue("Wholesaler ID");

                string result = wholesalerController.DeleteWholesaler(wholesalerId);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ViewAllWholesalers()
        {
            try
            {
                var wholesalers = wholesalerController.GetAllWholesalers();
                if (wholesalers == null)
                    throw new Exception("Wholesalers Not Found, Try Again...");
                Console.WriteLine($"\nTotal Wholesalers : {wholesalers.Count}\n");
                wholesalers.ForEach(wholesaler => Console.WriteLine(wholesaler));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SearchWholesaler()
        {
            int wholesalerId = UserInputs.GetValidIntegerValue("Wholesaler ID");

            var wholesaler = wholesalerController.GetWholesalerById(wholesalerId);
            try
            {
                if (wholesaler != null)
                {
                    Console.WriteLine("Wholesaler Found :\n" +
                        "" + wholesaler);
                    return;
                }
                throw new Exception("Wholesaler Not Found ...!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("\nWhat would you like to do under Wholesaler Management?\n" +
                              "1. Add New Wholesaler\n" +
                              "2. Update Wholesaler Details\n" +
                              "3. Delete Wholesaler\n" +
                              "4. View All Wholesalers\n" +
                              "5. Search Wholesaler By Id\n" +
                              "6. Back to Main Menu\n");
        }
    }
}
