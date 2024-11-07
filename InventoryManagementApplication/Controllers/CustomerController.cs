using InventoryManagementApplication.Models;
using InventoryManagementApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Controllers
{
    internal class CustomerController
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        // Add new customer
        public string AddCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
            return "Customer Added Successfully to The DataBase...!";
        }

        // Update customer details
        public string UpdateCustomer(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        // Delete a customer
        public string  DeleteCustomer(int customerId)
        {
           return  _customerRepository.Delete(customerId);
        }

        // Get all customers
        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        // Search for a customer by userId
        public Customer GetCustomerByUsername(int customerId)
        {
            return _customerRepository.GetCustomerById(customerId);
        }

    }
}
