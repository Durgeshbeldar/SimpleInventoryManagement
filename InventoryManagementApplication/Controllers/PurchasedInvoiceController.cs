using InventoryManagementApplication.Models;
using InventoryManagementApplication.Repositories;
using System.Collections.Generic;

namespace InventoryManagementApplication.Controllers
{
    internal class PurchasedInvoiceController : ProductController 
    {
        private PurchasedInvoiceRepository _repository;
        private WholesalerController _wholesalerController; 
        public PurchasedInvoiceController()
        {
            _repository = new PurchasedInvoiceRepository();
            _wholesalerController = new WholesalerController();
        }

        // Add New Purchased Invoice
        public int  AddPurchasedInvoice(PurchasedInvoice invoice)
        {
           return _repository.AddPurchasedInvoice(invoice);
        }
        public void UpdateInvoice(PurchasedInvoice invoice)
        {
            _repository.UpdateInvoice(invoice);
        }

        public void AddPurchasedItem(PurchasedItem item)
        {
            _repository.AddPurchasedItem(item);
        }


        //Get Invoices By Id
        public PurchasedInvoice GetPurchasedInvoiceById(int invoiceId)
        {
            return _repository.GetPurchasedInvoiceById(invoiceId);
        }



        // Get Invoice By Date
        public List<PurchasedInvoice> GetInvoicesByDate(DateTime date)
        {
            return _repository.GetPurchasedInvoicesByDate(date);
        }

        // Get All Invoices
        public List<PurchasedInvoice> GetAllPurchasedInvoices()
        {
            return _repository.GetAllPurchasedInvoices();
        }

        // Delete Invoices By Id
        public bool DeletePurchasedInvoice(int invoiceId)
        {
            return _repository.DeletePurchasedInvoice(invoiceId);
        }

        // WholeSaler Specific Methods...

        public List<Wholesaler> GetAllWholesalers()
        {
            return _wholesalerController.GetAllWholesalers();
        }
    }
}
