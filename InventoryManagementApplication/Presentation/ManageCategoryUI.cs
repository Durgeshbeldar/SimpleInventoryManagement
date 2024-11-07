using InventoryManagementApplication.Controllers;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;

namespace InventoryManagementApplication.Presentation
{
    internal class ManageCategoryUI
    {
        static CategoryController categoryController = new CategoryController();

        public static void ManageCategories()
        {
            while (true)
            {
                DisplayMenu();
                int choice = UserInputs.GetUserChoice(1, 7);
                switch (choice)
                {
                    case 1:
                        AddNewCategory();
                        break;
                    case 2:
                        UpdateCategory();
                        break;
                    case 3:
                        DeleteCategory();
                        break;
                    case 4:
                        ViewAllCategories();
                        break;
                    case 5:
                        SearchCategoryById();
                        break;
                    case 6:
                        SearchCategoryByName();
                        break;
                    case 7:
                        Console.WriteLine("Returned to Main Menu");
                        return;
                }
            }
        }

        // Add a new category
        static void AddNewCategory()
        {
            try
            {
                Console.WriteLine("Enter Category Name: ");
                string name = Console.ReadLine();

                Category category = new Category()
                {
                    Name = name
                };

                string result = categoryController.AddCategory(category);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void UpdateCategory()
        {
            try
            {
                int categoryId = UserInputs.GetValidIntegerValue("Category ID");

                Console.WriteLine("Enter New Category Name: ");
                string name = Console.ReadLine();

                Category category = new Category()
                {
                    CategoryId = categoryId,
                    Name = name
                };

                string result = categoryController.UpdateCategory(category);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Delete a category
        static void DeleteCategory()
        {
            try
            {
                int categoryId = UserInputs.GetValidIntegerValue("Category ID");

                string result = categoryController.DeleteCategory(categoryId);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // View all categories
        static void ViewAllCategories()
        {
            try
            {
                var categories = categoryController.GetAllCategories();
                if (categories == null || categories.Count == 0)
                    throw new Exception("No categories found.");

                Console.WriteLine($"\nTotal Categories: {categories.Count}\n");
                categories.ForEach(category => Console.WriteLine(category));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Search category by ID
        static void SearchCategoryById()
        {
            try
            {
                int categoryId = UserInputs.GetValidIntegerValue("Category ID");
                var category = categoryController.GetCategoryById(categoryId);

                if (category != null)
                {
                    Console.WriteLine("Category Found: ");
                    Console.WriteLine(category);
                    return;
                }
                throw new Exception("Category not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SearchCategoryByName()
        {
            try
            {
                Console.WriteLine("Enter Category Name :");
                string categoryName = Console.ReadLine();

                var category = categoryController.GetCategoryByName(categoryName);

                if (category != null)
                {
                    Console.WriteLine("Category Found: ");
                    Console.WriteLine(category);
                    return;
                }
                throw new Exception("Category Not Found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Display menu for managing categories
        public static void DisplayMenu()
        {
            Console.WriteLine("\nWhat would you like to do under Category Management?\n" +
                              "1. Add New Category\n" +
                              "2. Update Category Details\n" +
                              "3. Delete Category\n" +
                              "4. View All Categories\n" +
                              "5. Search Category By Id\n" +
                              "6. Search Category By Name\n" +
                              "7. Back to Main Menu\n");
        }
    }
}
