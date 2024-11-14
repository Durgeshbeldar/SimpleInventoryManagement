using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManagementApplication.Models;
using InventoryManagementApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementApplication.Repositories
{
    internal class SaleInvoiceRepository
    {
        private readonly InventoryContext _context;

        public SaleInvoiceRepository()
        {
            _context = new InventoryContext();
        }

        // Add a new Sales Invoice to the database
        public void AddSalesInvoice(SaleInvoice invoice)
        {
            _context.SaleInvoices.Add(invoice);
            _context.SaveChanges();
        }

        // Get a Sales Invoice by its ID
        public SaleInvoice GetSalesInvoiceById(int id)
        {
            return _context.SaleInvoices.Include(invoice => invoice.Customer)
                                         .FirstOrDefault(invoice => invoice.InvoiceId == id);
        }

        // Get all Sales Invoices by a specific date
        public List<SaleInvoice> GetSalesInvoicesByDate(DateTime date)
        {
            return _context.SaleInvoices
                           .Include(invoice => invoice.Customer)
                           .Where(invoice => invoice.InvoiceDate.Date == date.Date)
                           .ToList();
        }

        // Get all Sales Invoices
        public List<SaleInvoice> GetAllSalesInvoices()
        {
            return _context.SaleInvoices.Include(invoice => invoice.Customer).ToList();
        }

        // Delete a Sales Invoice by its ID
        public bool DeleteSalesInvoice(int id)
        {
            var invoice = _context.SaleInvoices.FirstOrDefault(invoice => invoice.InvoiceId == id);
            if (invoice != null)
            {
                _context.SaleInvoices.Remove(invoice);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
