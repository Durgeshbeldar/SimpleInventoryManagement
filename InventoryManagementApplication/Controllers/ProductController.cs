using InventoryManagementApplication.Models;
using InventoryManagementApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Controllers
{
    internal class ProductController
    {
        private readonly ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        // Add new product
        public string AddProduct(Product product)
        {
            _productRepository.Add(product);
            return "Product Added Successfully to The DataBase...!";
        }

        // Update product details
        public string UpdateProduct(Product product)
        {
            return _productRepository.Update(product);
        }

        // Delete a product
        public string DeleteProduct(int productId)
        {
            return _productRepository.Delete(productId);
        }

        // Get all products
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        // Search for a product by productId
        public Product GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }

        // Search by Category
        public List<Product> SearchByCategory(int categoryId)
        {
            return _productRepository.SearchByCategory(categoryId);
        }

        // Search by Brand
        public List<Product> SearchByBrand(int brandId)
        {
            return _productRepository.SearchByBrand(brandId);
        }

        // Search by both Category and Brand
        public List<Product> SearchByCategoryAndBrand(int categoryId, int brandId)
        {
            return _productRepository.SearchByCategoryAndBrand(categoryId, brandId);
        }
    }
}
