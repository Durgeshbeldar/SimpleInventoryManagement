using InventoryManagementApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Presentation
{
    internal class MainUI
    {
        static AdminController adminController = new AdminController();
        public static void InventoryLoginUI()
        {
            DisplayWelcome();
           // DashboardUI.InventoryDashBoard();
            Console.WriteLine("Enter Your User ID : ");
            string userId = Console.ReadLine().ToLower();
            Console.WriteLine("\nEnter Your Password :");
            string password = Console.ReadLine().ToLower();
            if (adminController.IsValidUser(userId, password))
            {
                Console.WriteLine("Login Successfull...!\n");
                DashboardUI.InventoryDashBoard();
                return;
            }
            else
                Console.WriteLine("\nIncorrect Credentials Please Try Again...!\n");

        }

        static void DisplayWelcome()
        {
            Console.WriteLine($"\n************************************** WELCOME TO INVENTORY MANAGEMENT SYSTEM **************************************" +
                $"\n\nLogin Window Please Login with Your Admin Credentials to Use Your Inventory Application :\n\n");
        }
    }
}
