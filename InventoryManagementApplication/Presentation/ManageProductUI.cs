using InventoryManagementApplication.Controllers;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Presentation
{
    internal class ManageProductUI
    {
        static ProductController productController = new ProductController();

        public static void ManageProducts()
        {
            while (true)
            {
                DisplayMenu();
                int choice = UserInputs.GetUserChoice(1, 9); // Assume a method to get user choice between 1 and 6
                switch (choice)
                {
                    case 1:
                        AddNewProduct();
                        break;
                    case 2:
                        UpdateProduct();
                        break;
                    case 3:
                        DeleteProduct();
                        break;
                    case 4:
                        ViewAllProducts();
                        break;
                    case 5:
                        SearchProduct();
                        break;
                    case 6:
                        SearchByCategory();
                        break;
                    case 7:
                        SearchByBrand();
                        break;
                    case 8:
                        SearchByCategoryAndBrand();
                        break;
                    case 9:
                        Console.WriteLine("Returned To Main Menu");
                        return;
                }
            }
        }

        // Add New Product
        static void AddNewProduct()
        {
            try
            {
                Console.WriteLine("Enter Product Details:");

                Console.WriteLine("Enter Product Name:");
                string name = Console.ReadLine();

                double purchasedPrice = UserInputs.GetValidIntegerValue("Purchased Price");

                double mrp = UserInputs.GetValidIntegerValue("MRP");

                int categoryId = UserInputs.GetValidIntegerValue("Category ID");

                int brandId = UserInputs.GetValidIntegerValue("Brand ID");

                Product product = new Product()
                {
                    Name = name,
                    PurchasedPrice = purchasedPrice,
                    MRP = mrp,
                    CategoryId = categoryId,
                    BrandId = brandId
                };

                string result = productController.AddProduct(product);
                Console.WriteLine(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Update Product
        static void UpdateProduct()
        {
            try
            {
                int productId = UserInputs.GetValidIntegerValue("Product ID");

                Console.WriteLine("Enter New Details for Product:");

                Console.WriteLine("Enter Product Name:");
                string name = Console.ReadLine();

                double purchasedPrice = UserInputs.GetValidIntegerValue("Purchased Price");

                double mrp = UserInputs.GetValidIntegerValue("MRP");

                int categoryId = UserInputs.GetValidIntegerValue("Category ID");

                int brandId = UserInputs.GetValidIntegerValue("Brand ID");

                Product product = new Product()
                {
                    ProductId = productId,
                    Name = name,
                    PurchasedPrice = purchasedPrice,
                    MRP = mrp,
                    CategoryId = categoryId,
                    BrandId = brandId
                };

                string result = productController.UpdateProduct(product);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Delete Product
        static void DeleteProduct()
        {
            try
            {
                int productId = UserInputs.GetValidIntegerValue("Product ID");

                string result = productController.DeleteProduct(productId);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // View All Products
        static void ViewAllProducts()
        {
            try
            {
                var products = productController.GetAllProducts();
                if (products == null || products.Count == 0)
                    throw new Exception("No Products Found.");

                Console.WriteLine($"\nTotal Products: {products.Count}\n");
                products.ForEach(product => Console.WriteLine(product));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Search Product by ID
        static void SearchProduct()
        {
            try
            {
                int productId = UserInputs.GetValidIntegerValue("Product ID");

                var product = productController.GetProductById(productId);

                if (product != null)
                {
                    Console.WriteLine("Product Found:\n" + product);
                    return;
                }
                throw new Exception("Product Not Found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SearchByCategory()
        {
            try
            {
                int categoryId = UserInputs.GetValidIntegerValue("Category ID");

                var products = productController.SearchByCategory(categoryId);

                if (products != null && products.Count > 0)
                {
                    Console.WriteLine($"\nProducts Found in Category {products[0].Category.Name}: {products.Count}\n");
                    products.ForEach(product => Console.WriteLine(product));
                    return;
                }
                throw new Exception("No Products Found for this Category.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Search by Brand
        static void SearchByBrand()
        {
            try
            {
                int brandId = UserInputs.GetValidIntegerValue("Brand ID");

                var products = productController.SearchByBrand(brandId);

                if (products != null && products.Count > 0)
                {
                    Console.WriteLine($"\nProducts Found for Brand {products[0].Brand.Name}: {products.Count}\n");
                    products.ForEach(product => Console.WriteLine(product));
                    return;
                }
            
                throw new Exception("No Products Found for this Brand.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Search by Category and Brand
        static void SearchByCategoryAndBrand()
        {
            try
            {
                int categoryId = UserInputs.GetValidIntegerValue("Category ID");
                int brandId = UserInputs.GetValidIntegerValue("Brand ID");

                var products = productController.SearchByCategoryAndBrand(categoryId, brandId);

                if (products != null && products.Count > 0)
                {
                    Console.WriteLine($"\nProducts Found for Category {categoryId} and Brand {brandId}: {products.Count}\n");
                    products.ForEach(product => Console.WriteLine(product));
                    return;
                }
               
                throw new Exception("No Products Found for this Category and Brand.");
           
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Display Menu
        public static void DisplayMenu()
        {
            Console.WriteLine("\nWhat would you like to do under Product Management?\n" +
                              "1. Add New Product\n" +
                              "2. Update Product Details\n" +
                              "3. Delete Product\n" +
                              "4. View All Products\n" +
                              "5. Search Product By Id\n" +
                              "6. View Products By Category\n" +
                              "7. View Products By Brands\n" +
                              "8. View Products By Category and Brand\n" +
                              "9. Back to Main Menu\n");
        }
    }
}
