using InventoryManagementApplication.Data;
using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Repositories
{
    internal class CustomerRepository
    {
        private readonly InventoryContext _inventoryContext; 

        public CustomerRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        public void SaveChanges()
        {
            _inventoryContext.SaveChanges();
        }

        public void Add(Customer customer)
        {
            _inventoryContext.Customers.Add(customer);
            _inventoryContext.SaveChanges();  
        }

        // Update Customer in Database
        public string Update(Customer customer)
        {
            var existingCustomer = _inventoryContext.Customers
                .FirstOrDefault(c => c.CustomerId == customer.CustomerId);

            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.ContactNumber = customer.ContactNumber;
                existingCustomer.Address = customer.Address;

                SaveChanges();  
                return "Customer updated successfully!";
            }
            return "Customer Not Found!";
        }



        // Delete customer from DB
        public string Delete(int customerId)
        {
            var customer = _inventoryContext.Customers
                .FirstOrDefault(c => c.CustomerId == customerId);

            if (customer != null)
            {
                _inventoryContext.Customers.Remove(customer);  
                _inventoryContext.SaveChanges();  
                return "Customer deleted successfully!";
            }
            return "Customer Not Found";
        }

        
        public List<Customer> GetAll()
        {
            return _inventoryContext.Customers.ToList();  
        }

       
        public Customer GetCustomerById(int Id)
        {
            return _inventoryContext.Customers
                .FirstOrDefault(customer => customer.CustomerId == Id); 
        }
    }
}
