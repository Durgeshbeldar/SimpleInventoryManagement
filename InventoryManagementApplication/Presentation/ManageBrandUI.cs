using InventoryManagementApplication.Controllers;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;

namespace InventoryManagementApplication.Presentation
{
    internal class ManageBrandUI
    {
        static BrandController brandController = new BrandController();

        public static void ManageBrands()
        {
            while (true)
            {
                DisplayMenu();
                int choice = UserInputs.GetUserChoice(1, 7);
                switch (choice)
                {
                    case 1:
                        AddNewBrand();
                        break;
                    case 2:
                        UpdateBrand();
                        break;
                    case 3:
                        DeleteBrand();
                        break;
                    case 4:
                        ViewAllBrands();
                        break;
                    case 5:
                        SearchBrandById();
                        break;
                    case 6:
                        SearchBrandByName();
                        break;
                    case 7:
                        Console.WriteLine("Returned to Main Menu");
                        return;
                }
            }
        }

        // Add a new brand
        static void AddNewBrand()
        {
            try
            {
                Console.WriteLine("Enter Brand Name: ");
                string name = Console.ReadLine();

                Brand brand = new Brand()
                {
                    Name = name
                };

                string result = brandController.AddBrand(brand);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Update a brand
        static void UpdateBrand()
        {
            try
            {
                int brandId = UserInputs.GetValidIntegerValue("Brand ID");

                Console.WriteLine("Enter New Brand Name: ");
                string name = Console.ReadLine();

                Brand brand = new Brand()
                {
                    BrandId = brandId,
                    Name = name
                };

                string result = brandController.UpdateBrand(brand);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Delete a brand
        static void DeleteBrand()
        {
            try
            {
                int brandId = UserInputs.GetValidIntegerValue("Brand ID");

                string result = brandController.DeleteBrand(brandId);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // View all brands
        static void ViewAllBrands()
        {
            try
            {
                var brands = brandController.GetAllBrands();
                if (brands == null || brands.Count == 0)
                    throw new Exception("No brands found.");

                Console.WriteLine($"\nTotal Brands: {brands.Count}\n");
                brands.ForEach(brand => Console.WriteLine(brand));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Search brand by ID
        static void SearchBrandById()
        {
            try
            {
                int brandId = UserInputs.GetValidIntegerValue("Brand ID");
                var brand = brandController.GetBrandById(brandId);

                if (brand != null)
                {
                    Console.WriteLine("Brand Found: ");
                    Console.WriteLine(brand);
                    return;
                }
                throw new Exception("Brand not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Search brand by name
        static void SearchBrandByName()
        {
            try
            {
                Console.WriteLine("Enter Brand Name :");
                string brandName = Console.ReadLine();

                var brand = brandController.GetBrandByName(brandName);

                if (brand != null)
                {
                    Console.WriteLine("Brand Found: ");
                    Console.WriteLine(brand);
                    return;
                }
                throw new Exception("Brand Not Found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Display menu for managing brands
        public static void DisplayMenu()
        {
            Console.WriteLine("\nWhat would you like to do under Brand Management?\n" +
                              "1. Add New Brand\n" +
                              "2. Update Brand Details\n" +
                              "3. Delete Brand\n" +
                              "4. View All Brands\n" +
                              "5. Search Brand By Id\n" +
                              "6. Search Brand By Name\n" +
                              "7. Back to Main Menu\n");
        }
    }
}
