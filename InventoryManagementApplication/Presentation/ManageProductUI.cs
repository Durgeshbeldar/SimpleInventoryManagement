using InventoryManagementApplication.Controllers;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
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
                Console.WriteLine("Enter Product Name:");
                string name = Console.ReadLine();

                double purchasedPrice = UserInputs.GetValidIntegerValue("Purchased Price");

                double mrp = UserInputs.GetValidIntegerValue("MRP");
                int categoryId = GetCategory();

                int brandId = GetBrand();

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

        static void DisplayCategories(List<Category> categories)
        {
            int count = 0;
            foreach (Category category in categories)
            {
                ++count;
                Console.WriteLine($"{count}. {category.Name}");
            }
        }
        static int GetCategory()
        {
            CategoryController categoryController = new CategoryController();
            string isExisting = UserInputs.GetValidYesNoInput("Category");
            int userCategory;
            if(isExisting == "yes")
            {
                List <Category> categories = categoryController.GetAllCategories();
                DisplayCategories(categories);
                userCategory = UserInputs.GetUserChoice(1, categories.Count) -1;
                Console.WriteLine("Category Selected");
                return categories[userCategory].CategoryId;
            }
            try
            {
                Console.WriteLine("Enter New Category Name :");
                string categoryName = Console.ReadLine();
                Category newCategory = new Category() { Name = categoryName };
                string result = categoryController.AddCategory(newCategory);
                Console.WriteLine(result);
                Category newCategoryRetrival = categoryController.GetCategoryByName(categoryName);
                Console.WriteLine("Category Selected");
                return newCategoryRetrival.CategoryId;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetCategory();
            }
        }

        static int GetBrand()
        {
            BrandController brandController = new BrandController();
            string isExisting = UserInputs.GetValidYesNoInput("Brand");
            int userBrand;

            if (isExisting == "yes")
            {
                List<Brand> brands = brandController.GetAllBrands();
                int count = 0;
                foreach (Brand brand in brands)
                {
                    ++count;
                    Console.WriteLine($"{count}. {brand.Name}");
                }
                userBrand = UserInputs.GetUserChoice(1, brands.Count) - 1;
                Console.WriteLine("Brand Selected");
                return brands[userBrand].BrandId;
            }

            try
            {
                Console.WriteLine("Enter New Brand Name:");
                string brandName = Console.ReadLine();
                Brand newBrand = new Brand() { Name = brandName };
                string result = brandController.AddBrand(newBrand);
                Console.WriteLine(result);

                Brand newBrandRetrieval = brandController.GetBrandByName(brandName);
                Console.WriteLine("Brand Selected");
                return newBrandRetrieval.BrandId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetBrand();
            }
        }


        // Update Product
        static void UpdateProduct()
        {
            try
            {
                int productId = UserInputs.GetValidIntegerValue("Product ID");

                Console.WriteLine("Enter Product Name:");
                string name = Console.ReadLine();

                double purchasedPrice = UserInputs.GetValidIntegerValue("Purchased Price");

                double mrp = UserInputs.GetValidIntegerValue("MRP");

                int categoryId = GetCategory();

                int brandId = GetBrand();

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


        static void DisplayProduct(Product product)
        {
           Console.WriteLine($"Product Found and Details Are :\n\n" +
               $"Product Name : {product.Name}\n" +
               $"Category : {product.Category.Name}\n" +
               $"Brand : {product.Brand.Name}\n" +
               $"Max Retail Price : {product.MRP}\n" +
               $"Wholesale Price : {product.PurchasedPrice}\n");

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
                    DisplayProduct(product);
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
                Console.WriteLine("Select Categories From Following List :");
                CategoryController controller = new CategoryController();
                List<Category> categories = controller.GetAllCategories();
                DisplayCategories(categories);
                int choice = UserInputs.GetUserChoice(1, categories.Count);

                int categoryId = categories[choice-1].CategoryId;
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

        public static void DisplayBrand(List<Brand> brands)
        {
            int count = 0;
            brands.ForEach(brand =>
            {
                ++count;
                Console.WriteLine($"{count}. {brand.Name}");
            });
        }

        // Search by Brand
        static void SearchByBrand()
        {
            try
            {
                Console.WriteLine("Select Brand From Following List :");
                BrandController controller = new BrandController();
                List<Brand> brands = controller.GetAllBrands();

                DisplayBrand(brands);
                int choice = UserInputs.GetUserChoice(1, brands.Count);
                int brandId = brands[choice-1].BrandId;
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
                BrandController brandController = new BrandController();
                CategoryController categoryController = new CategoryController();
                List<Brand> brands = brandController.GetAllBrands();
                List<Category> categories = categoryController.GetAllCategories();
                Console.WriteLine("Select Category To Filtered Products :");
                DisplayCategories(categories);
                int choice1 = UserInputs.GetUserChoice(1, categories.Count);
                Console.WriteLine("Select Brand For Filtered Products :");
                DisplayBrand(brands);
                int choice2 = UserInputs.GetValidIntegerValue("Brand ID");
                int categoryId = categories[choice1 - 1].CategoryId;
                int brandId = brands[choice2- 1].BrandId;

                var products = productController.SearchByCategoryAndBrand(categoryId, brandId);

                if (products != null && products.Count > 0)
                {
                    Console.WriteLine($"\nProducts Found for (Category : {products[0].Category.Name} and Brand : {products[0].Brand.Name}): {products.Count}\n");
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
