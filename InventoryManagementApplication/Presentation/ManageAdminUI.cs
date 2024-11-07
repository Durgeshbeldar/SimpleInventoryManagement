using InventoryManagementApplication.Controllers;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Presentation
{
    internal class ManageAdminUI
    {
        static AdminController _adminController = new AdminController();
        public static void ManageAdmins()
        {
            while (true)
            {
                DisplayMenu();
                int choice = UserInputs.GetUserChoice(1,6);
                switch (choice)
                {
                    case 1:
                        AddNewAdmin();
                        break;
                    case 2:
                        UpdateAdminDetails();
                        break;
                    case 3:
                        DeleteAdmin();
                        break;
                    case 4:
                        ViewAllAdmins();
                        break;
                    case 5:
                        SearchAdminByUsername();
                        break;
                    case 6:
                        Console.WriteLine("Returning to Main Menu...!");
                        return;
                }
            }
        }


        // Add New Admin
        static void AddNewAdmin()
        {
            try
            {
                Console.WriteLine("Enter UserName For New Admin: ");
                string userId = Console.ReadLine();
                Console.WriteLine("\nEnter Admin Full Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("\nEnter Password: ");
                string password = Console.ReadLine();

                Admin newAdmin = new Admin(userId, name, password);
            
                string result = _adminController.AddAdmin(newAdmin);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        // Update Admin Details
        static void UpdateAdminDetails()
        {
            try
            {
                Console.WriteLine("Enter UserId of Admin to Update: ");
                string userId = Console.ReadLine();
                Console.WriteLine("Enter New Admin Name: ");
                string name = Console.ReadLine();

                string result = _adminController.UpdateAdmin(userId, name);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Delete Admin in Database...
        static void DeleteAdmin()
        {
            try
            {
                Console.WriteLine("Enter UserName of Admin to Delete: ");
                string userId = Console.ReadLine();

                string result = _adminController.DeleteAdmin(userId);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // View All Admins
        static void ViewAllAdmins()
        {
            try
            {
                List<Admin> admins = _adminController.GetAllAdmins();
                if (admins.Count == 0)
                {
                    Console.WriteLine("No Admins Found!");
                    return;
                }
                Console.WriteLine($"Total {admins.Count} Found:\n");
                admins.ForEach(ad => Console.WriteLine(ad));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void SearchAdminByUsername()
        {
            try
            {
                Console.WriteLine("Enter UserName of Admin to Search: ");
                string userId = Console.ReadLine();

                Admin admin = _adminController.FindAdminById(userId);
                if (admin != null)
                {
                    Console.WriteLine("Admin Found :\n" +
                        ""+admin);
                    return;
                }
                Console.WriteLine("Admin Not Found!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nWhat would you like to do under Admin Management?\n" +
                  "1. Add New Admin\n" +
                  "2. Update Admin Details\n" +
                  "3. Delete Admin\n" +
                  "4. View All Admins\n" +
                  "5. Search Admin by Username\n" +
                  "6. Back to Main Menu\n");
        }
    }
}
