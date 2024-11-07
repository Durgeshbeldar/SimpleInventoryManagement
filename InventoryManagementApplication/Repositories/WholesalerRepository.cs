using InventoryManagementApplication.Data;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Repositories
{
    internal class WholesalerRepository
    {
        private readonly InventoryContext _inventoryContext;  

        public WholesalerRepository()
        {
            _inventoryContext = new InventoryContext();  
        }

        public void SaveChanges()
        {
            _inventoryContext.SaveChanges();  
        }

        // Add a new wholesaler
        public void Add(Wholesaler wholesaler)
        {
            _inventoryContext.Wholesalers.Add(wholesaler);  
            _inventoryContext.SaveChanges();  
        }

        // Update an existing wholesaler
        public string Update(Wholesaler wholesaler)
        {
            var existingWholesaler = _inventoryContext.Wholesalers
                .FirstOrDefault(w => w.WholesalerId == wholesaler.WholesalerId);

            if (existingWholesaler != null)
            {
                existingWholesaler.Name = wholesaler.Name; 
                existingWholesaler.ContactNumber = wholesaler.ContactNumber; 
                existingWholesaler.Address = wholesaler.Address;  

                SaveChanges(); 
                return "Wholesaler updated successfully!";
            }
            return "Wholesaler Not Found!";
        }

        // Delete a wholesaler
        public string Delete(int wholesalerId)
        {
            var wholesaler = _inventoryContext.Wholesalers
                .FirstOrDefault(w => w.WholesalerId == wholesalerId);  

            if (wholesaler != null)
            {
                _inventoryContext.Wholesalers.Remove(wholesaler);  
                _inventoryContext.SaveChanges();  
                return "Wholesaler deleted successfully!";
            }
            return "Wholesaler Not Found!";
        }

        // Get all wholesalers
        public List<Wholesaler> GetAll()
        {
            return _inventoryContext.Wholesalers.ToList();  
        }

        // Get a wholesaler by ID
        public Wholesaler GetWholesalerById(int Id)
        {
            return _inventoryContext.Wholesalers
                .FirstOrDefault(wholesaler => wholesaler.WholesalerId == Id);  
        }
    }
}
