using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManagementApplication.Models;
using InventoryManagementApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementApplication.Repositories
{
    internal class PurchasedInvoiceRepository
    {
        private readonly InventoryContext _context;

        public PurchasedInvoiceRepository()
        {
            _context = new InventoryContext();
        }

        public void AddPurchasedInvoice(PurchasedInvoice invoice)
        {
            _context.PurchasedInvoices.Add(invoice);
            _context.SaveChanges();
        }

        public PurchasedInvoice GetPurchasedInvoiceById(int id)
        {
            return _context.PurchasedInvoices.Include(invoice => invoice.Wholesaler).FirstOrDefault(invoice => invoice.InvoiceId == id);
        }

        public List<PurchasedInvoice> GetPurchasedInvoicesByDate(DateTime date)
        {
            return _context.PurchasedInvoices
                           .Include(invoice => invoice.Wholesaler) 
                           .Where(invoice => invoice.InvoiceDate.Date == date.Date) 
                           .ToList();
        }
        public List<PurchasedInvoice> GetAllPurchasedInvoices()
        {
            return _context.PurchasedInvoices.Include(invoice => invoice.Wholesaler).ToList();
        }

      
        public bool DeletePurchasedInvoice(int id)
        {
            var invoice = _context.PurchasedInvoices.FirstOrDefault(invoice => invoice.InvoiceId == id);
            if (invoice != null)
            {
                _context.PurchasedInvoices.Remove(invoice);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
