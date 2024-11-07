using InventoryManagementApplication.Data;
using InventoryManagementApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Repositories
{
    internal class ProductRepository
    {
        private readonly InventoryContext _inventoryContext;

        public ProductRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        public void SaveChanges()
        {
            _inventoryContext.SaveChanges();
        }

        // Add new product
        public void Add(Product product)
        {
            _inventoryContext.Products.Add(product);
            SaveChanges();
        }

        // Update Product
        public string Update(Product product)
        {
            var existingProduct = _inventoryContext.Products
                .FirstOrDefault(p => p.ProductId == product.ProductId);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.PurchasedPrice = product.PurchasedPrice;
                existingProduct.MRP = product.MRP;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.BrandId = product.BrandId;

                SaveChanges();
                return "Product updated successfully!";
            }
            return "Product Not Found!";
        }

        // Delete a product
        public string Delete(int productId)
        {
            var product = _inventoryContext.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                _inventoryContext.Products.Remove(product);
                SaveChanges();
                return "Product deleted successfully!";
            }
            return "Product Not Found!";
        }

        // Get all products
        public List<Product> GetAll()
        {
            return _inventoryContext.Products.ToList();
        }

        // Get With Categories
        public List<Product> GetAllWithCategory()
        {
            return _inventoryContext.Products
                .Include(p => p.Category) 
                .ToList();
        }

        // Get All With Brand
        public List<Product> GetAllWithBrand()
        {
            return _inventoryContext.Products
                .Include(p => p.Brand)
                .ToList();
        }


        // Get All With Category and Brand
        public List<Product> GetAllWithCategoryAndBrand()
        {
            return _inventoryContext.Products
                .Include(p => p.Category).Include(p => p.Brand)
                .ToList();
        }

        // Get product by ID
        public Product GetProductById(int productId)
        {
            return _inventoryContext.Products
                .FirstOrDefault(p => p.ProductId == productId);
        }


        // Search by Category
        public List<Product> SearchByCategory(int categoryId)
        {
            var products = GetAllWithCategory();
            return products.Where(p => p.CategoryId == categoryId).ToList();
        }

        // Search by Brand
        public List<Product> SearchByBrand(int brandId)
        {
            var products = GetAllWithBrand();
            return products.Where(p => p.BrandId == brandId).ToList();
        }

        // Search by Category and Brand
        public List<Product> SearchByCategoryAndBrand(int categoryId, int brandId)
        {
            var products = GetAllWithCategoryAndBrand();
            return products.Where(p => p.CategoryId == categoryId && p.BrandId == brandId).ToList();
        }
    }
}
