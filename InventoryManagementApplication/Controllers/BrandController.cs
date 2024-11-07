using InventoryManagementApplication.Models;
using InventoryManagementApplication.Repositories;
using System.Collections.Generic;

namespace InventoryManagementApplication.Controllers
{
    public class BrandController
    {
        private BrandRepository _brandRepository;

        public BrandController()
        {
            _brandRepository = new BrandRepository();
        }

        // Add brand
        public string AddBrand(Brand brand)
        {
            return _brandRepository.Add(brand);
            
        }

        // Update brand
        public string UpdateBrand(Brand brand)
        {
            return _brandRepository.Update(brand);
        }

        // Delete brand
        public string DeleteBrand(int brandId)
        {
            return _brandRepository.Delete(brandId);
        }

        // Get all brands
        public List<Brand> GetAllBrands()
        {
            return _brandRepository.GetAll();
        }

        // Get brand by ID
        public Brand GetBrandById(int brandId)
        {
            return _brandRepository.GetById(brandId);
        }

        // Get brand by name
        public Brand GetBrandByName(string brandName)
        {
            return _brandRepository.GetByName(brandName);
        }
    }
}
