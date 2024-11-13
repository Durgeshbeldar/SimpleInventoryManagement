using InventoryManagementApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InventoryManagementApplication.Presentation
{
    internal class UserInputs
    {
        public static int GetUserChoice(int from, int to)
        {
            int userInput;
            try
            {
                Console.Write($"\n Select Valid Option From Above List :\n ");
                userInput = int.Parse(Console.ReadLine());
                if(userInput >= from && userInput<= to) 
                return userInput;
                throw new InvalidUserInputException($"Invalid User Input Please Select The Option Between {from} to {to}");
            }catch (InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
                return GetUserChoice(from, to); 
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetUserChoice(from, to);
            }
        }

        public static int GetValidIntegerValue(string entityName)
        {
            int userInput;
            try
            {
                Console.WriteLine($"Enter Your {entityName} :");
                userInput = int.Parse(Console.ReadLine());
                return userInput;
            }catch (InvalidUserInputException ex)
            {
                Console.WriteLine (ex.Message); 
                return GetValidIntegerValue(entityName);
            }
        }

        public static string GetValidYesNoInput(string entityName)
        {
            try
            {
                Console.WriteLine($"Do You Want to Select Existing {entityName} ? Enter Yes OR No :");
                string userChoice = Console.ReadLine().ToLower();
                if (userChoice != "yes" && userChoice != "no")
                    throw new InvalidUserInputException("Please Select Yes or No Only...!");
                return userChoice;
            }catch(InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
                return GetValidYesNoInput(entityName);
            }
        }

        public static int GetOneOrTwo()
        {
            Console.WriteLine("Enter Your Input :");
            int userInput;
            try
            {
                userInput = int.Parse(Console.ReadLine());
                if (userInput == 1 || userInput == 2)
                    return userInput;
                throw new InvalidUserInputException("Invalid Input, Please Choose One OR Two Only");
            }catch(InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
                return GetOneOrTwo();
            }
        }

        public static DateTime GetValidDate()
        {
            DateTime validDate;
            string userInput;

            while (true)
            {
                Console.WriteLine("Please enter a date (in format MM/dd/yyyy):");
                userInput = Console.ReadLine();

                if (IsValidDate(userInput, out validDate))
                return validDate;
                Console.WriteLine("The date entered is invalid. Please try again.");
            }
        }
        static bool IsValidDate(string dateInput, out DateTime parsedDate)
        {
            return DateTime.TryParseExact(dateInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate);
        }

    }
}
