using InventoryManagementApplication.Data;
using InventoryManagementApplication.Models;
using InventoryManagementApplication.Repositories;
using System.Collections.Generic;

namespace InventoryManagementApplication.Controllers
{
    internal class CategoryController
    {
        private CategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }

        // Add a new category
        public string AddCategory(Category category)
        {
            return _categoryRepository.Add(category);
        }

        // Update category details
        public string UpdateCategory(Category category)
        {
            return _categoryRepository.Update(category);
        }

        // Delete a category
        public string DeleteCategory(int categoryId)
        {
            return _categoryRepository.Delete(categoryId);
        }

        // Get all categories
        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        // Get category by ID
        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetById(categoryId);
        }

        public Category GetCategoryByName(string categoryName)
        {
            return _categoryRepository.GetByName(categoryName);
        }
    }
}
