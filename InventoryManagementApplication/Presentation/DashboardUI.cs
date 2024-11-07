﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Presentation
{
    internal class DashboardUI
    {
       
       public static void InventoryDashBoard()
       {
            Console.WriteLine("\n************************************ WELCOME TO INVENTORY DASHBOARD ************************************\n\n");

            while (true) 
            {
                DisplayMainMenu();
                int choice = UserInputs.GetUserChoice(1,9);
                switch (choice)
                {
                    case 1:
                        ManageAdminUI.ManageAdmins();
                        break;
                    case 2:
                        ManageCustomerUI.ManageCustomers();
                        break;
                    case 3:
                        ManageWholesalerUI.ManageWholesalers();
                        break;
                    case 9:
                        Console.WriteLine("Log Out From Admin Inventory Dashboard");
                        return;
                    default:
                        Console.WriteLine("Invalid Input, Please Choose Correct Option!");
                        break;

                }

            }

       }
       
       static void DisplayMainMenu()
       {
            Console.WriteLine($"\nWhat Do You Wish to Do?\n" +
                $"1.  Manage Admins\n" +
                $"2.  Manage Customers\n" +
                $"3.  Manage Wholesalers\n" +
                $"4.  Manage Products\n" +
                $"5.  Manage Product Categories\n" +
                $"6.  Manage Product Brands\n" +
                $"7.  Create New Sale\n" +
                $"8.  Create Purchased\n" +
                $"9.  View/Manage Stocks\n" +
                $"10. View Profile\n" +
                $"11. Logout\n");   
       }


        

    }
}