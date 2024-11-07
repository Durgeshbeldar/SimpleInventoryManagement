using InventoryManagementApplication.Data;
using InventoryManagementApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementApplication.Repositories
{
    internal class BrandRepository
    {
        private InventoryContext _inventoryContext;

        public BrandRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        // Get all brands
        public List<Brand> GetAll()
        {
            return _inventoryContext.Brands.ToList();
        }

        bool IsExist(string name)
        {
            return _inventoryContext.Brands.Any(b => b.Name.ToLower() == name.ToLower());
        }
        // Add a new brand
        public string Add(Brand brand)
        {
            if (IsExist(brand.Name))
                throw new Exception("Brand Name Already Exist, Brand Name Should be Unique.");
            _inventoryContext.Brands.Add(brand);
            _inventoryContext.SaveChanges();
            return "Brand added successfully!";
        }

        // Update an existing brand
        public string Update(Brand brand)
        {
            var existingBrand = _inventoryContext.Brands
                .FirstOrDefault(b => b.BrandId == brand.BrandId);

            if (existingBrand == null)
                return "Brand Not Found.";

            existingBrand.Name = brand.Name;
            _inventoryContext.SaveChanges();
            return "Brand updated successfully!";
        }

        // Delete Brand
        public string Delete(int brandId)
        {
            var brand = _inventoryContext.Brands
                .FirstOrDefault(b => b.BrandId == brandId);

            if (brand == null)
                return "Brand Not Found.";

            _inventoryContext.Brands.Remove(brand);
            _inventoryContext.SaveChanges();
            return "Brand deleted successfully!";
        }

        // Get a brand by its ID
        public Brand GetById(int brandId)
        {
            return _inventoryContext.Brands
                .FirstOrDefault(b => b.BrandId == brandId);
        }

        // Get a brand by its name
        public Brand GetByName(string brandName)
        {
            return _inventoryContext.Brands
                .FirstOrDefault(b => b.Name.ToLower() == brandName.ToLower());
        }
    }
}
