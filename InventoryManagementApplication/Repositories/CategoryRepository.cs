using InventoryManagementApplication.Data;
using InventoryManagementApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementApplication.Repositories
{
    internal class CategoryRepository
    {
        private InventoryContext _inventoryContext;

        public CategoryRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        // Get all categories
        public List<Category> GetAll()
        {
            return _inventoryContext.Categories.ToList();
        }
        bool IsExist(string categoryName)
        {
            return _inventoryContext.Categories.Any(c => c.Name.ToLower() == categoryName.ToLower());
        }

        // Add a new category
        public string Add(Category category)
        {
            if (IsExist(category.Name))
                throw new Exception("Category Already Exist, Category Name Should Be Unique...");
            _inventoryContext.Categories.Add(category);
            _inventoryContext.SaveChanges();
            return "Category added successfully!";
        }

        // Update an existing category
        public string Update(Category category)
        {
            var existingCategory = _inventoryContext.Categories
                .FirstOrDefault(c => c.CategoryId == category.CategoryId);

            if (existingCategory == null)
                return "Category Not Found.";

            existingCategory.Name = category.Name;
            _inventoryContext.SaveChanges();
            return "Category updated successfully!";
        }

        // Delete Category
        public string Delete(int categoryId)
        {
            var category = _inventoryContext.Categories
                .FirstOrDefault(c => c.CategoryId == categoryId);

            if (category == null)
                return "Category Not Found.";

            _inventoryContext.Categories.Remove(category);
            _inventoryContext.SaveChanges();
            return "Category deleted successfully!";
        }

        // Get a category by its ID
        public Category GetById(int categoryId)
        {
            return _inventoryContext.Categories
                .FirstOrDefault(c => c.CategoryId == categoryId);
        }
        // Get a category by its ID
        public Category GetByName(string categoryName)
        {
            return _inventoryContext.Categories
                .FirstOrDefault(c => c.Name.ToLower() == categoryName.ToLower());
        }

    }
}
