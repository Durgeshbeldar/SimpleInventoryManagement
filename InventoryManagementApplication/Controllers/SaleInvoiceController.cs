using InventoryManagementApplication.Models;
using InventoryManagementApplication.Repositories;
using System.Collections.Generic;
using System;

namespace InventoryManagementApplication.Controllers
{
    internal class SaleInvoiceController : ProductController
    {
        private SaleInvoiceRepository _repository;
        private CustomerController _customerController; // To manage customer-related data

        public SaleInvoiceController()
        {
            _repository = new SaleInvoiceRepository();
            _customerController = new CustomerController();
        }

        // Add New Sales Invoice
        public void AddSalesInvoice(SaleInvoice invoice)
        {
            _repository.AddSalesInvoice(invoice);
        }

        // Get Sales Invoice By ID
        public SaleInvoice GetSalesInvoiceById(int invoiceId)
        {
            return _repository.GetSalesInvoiceById(invoiceId);
        }

        // Get Sales Invoices By Date
        public List<SaleInvoice> GetSalesInvoicesByDate(DateTime date)
        {
            return _repository.GetSalesInvoicesByDate(date);
        }

        // Get All Sales Invoices
        public List<SaleInvoice> GetAllSalesInvoices()
        {
            return _repository.GetAllSalesInvoices();
        }

        // Delete Sales Invoice By ID
        public bool DeleteSalesInvoice(int invoiceId)
        {
            return _repository.DeleteSalesInvoice(invoiceId);
        }

        // Customer Specific Methods...

        // Get all customers
        public List<Customer> GetAllCustomers()
        {
            return _customerController.GetAllCustomers();
        }

        // Add a new customer (if needed for invoice creation)
        public void AddCustomer(Customer customer)
        {
            _customerController.AddCustomer(customer);
        }

        // Get customer by ID
        public Customer GetCustomerById(int customerId)
        {
            return _customerController.GetCustomerByUsername(customerId);
        }
    }
}
