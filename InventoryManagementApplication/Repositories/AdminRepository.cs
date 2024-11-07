using InventoryManagementApplication.Data;
using InventoryManagementApplication.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Repositories
{
    internal class AdminRepository
    {
        private InventoryContext _inventoryContext;

        public AdminRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        public void AddAdmin(Admin admin)
        {
            _inventoryContext.Admins.Add(admin);  
            _inventoryContext.SaveChanges();
        }

        public bool IsValidAdmin(string userId, string password)
        {
            return _inventoryContext.Admins.Any(admin => admin.UserId.ToLower() == userId && admin.Password.ToLower() == password);
        }

        public Admin FindAdminById(string id)
        {
            return _inventoryContext.Admins.FirstOrDefault(admin => admin.UserId == id);
        }

        public void SaveChanges()
        {
            _inventoryContext.SaveChanges();
        }
        // Used to Update Admin Details
        public string UpdateAdmin(string userId, string name)
        {
            var admin = _inventoryContext.Admins.FirstOrDefault(a => a.UserId == userId);
            if (admin != null)
            {
                admin.Name = name;
                _inventoryContext.SaveChanges();
                return "\n Admin Updated Successfully!";
            }
            return "\nAdmin Not Found!";
        }

        public List<Admin> GetAllAdmins()
        {
            return _inventoryContext.Admins.ToList();
        }

        public string DeleteAdmin(string userId)
        {
            var admin = _inventoryContext.Admins.FirstOrDefault(a => a.UserId == userId);
            if (admin != null)
            {
                _inventoryContext.Admins.Remove(admin);
                _inventoryContext.SaveChanges();
                return "\nAdmin Deleted Successfully!";
            }
            return "\nAdmin Not Found!";
        }
    }
}
