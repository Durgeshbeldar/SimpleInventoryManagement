using InventoryManagementApplication.Models;
using InventoryManagementApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Controllers
{
    internal class AdminController
    {
        private AdminRepository _adminRepository;
        public AdminController() 
        {
            _adminRepository = new AdminRepository();
        }

        public bool IsValidUser(string userId, string password)
        {
            return _adminRepository.IsValidAdmin(userId, password);
        }

        public string AddAdmin(Admin admin)
        {
            _adminRepository.AddAdmin(admin);
            return "New Admin Added Successfully!";   
        }


        // Method to Update Admin Details
        public string UpdateAdmin(string userId, string name)
        {
            try
            {
                return _adminRepository.UpdateAdmin(userId, name);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating admin: " + ex.Message);
            }
        }

        // Method to Delete Admin by User ID
        public string DeleteAdmin(string userId)
        {
            try
            {
                return _adminRepository.DeleteAdmin(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting admin: " + ex.Message);
            }
        }

        // Method to Get All Admins
        public List<Admin> GetAllAdmins()
        {
            try
            {
                return _adminRepository.GetAllAdmins();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching all admins: " + ex.Message);
            }
        }

        // Method to Find Admin by User ID
        public Admin FindAdminById(string userId)
        {
            try
            {
                return _adminRepository.FindAdminById(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching admin by ID: " + ex.Message);
            }
        }


    }
}
