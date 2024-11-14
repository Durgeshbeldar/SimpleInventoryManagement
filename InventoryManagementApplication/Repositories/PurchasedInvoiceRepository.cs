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

        public int AddPurchasedInvoice(PurchasedInvoice newInvoice)
        {
            
            _context.PurchasedInvoices.Add(newInvoice);
            _context.SaveChanges();
            var existingInvoice = _context.PurchasedInvoices.Where
                (invoice => invoice.InvoiceDate == newInvoice.InvoiceDate).FirstOrDefault();
            if (existingInvoice != null)
            return existingInvoice.InvoiceId;
            return 0;
        }

        public void UpdateInvoice(PurchasedInvoice newInvoice)
        {
            var existingInvoice = _context.PurchasedInvoices.Find(newInvoice.InvoiceId);
            if (existingInvoice != null)
            {
                existingInvoice.InvoiceDate = newInvoice.InvoiceDate;
                existingInvoice.LineItems = newInvoice.LineItems;
                existingInvoice.TotalAmount = newInvoice.TotalAmount;
            }
        }

        public void AddPurchasedItem(PurchasedItem purchasedItem)
        {
            try
            {
                _context.PurchasedItems.Add(purchasedItem);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString);
            }
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
