using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    internal class PurchasedInvoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [ForeignKey("Wholesaler")]
        public int WholesalerId { get; set; }

        public List<PurchasedItem> PurchasedItems {  get; set; }
        public DateTime InvoiceDate { get; set; }  
        
        public double TotalAmount { get; set; }

        public Wholesaler Wholesaler { get; set; }
        public PurchasedInvoice()
        {
            PurchasedItems = new List<PurchasedItem>();
        }
        public PurchasedInvoice(int wholesalerId)
        {
            WholesalerId = wholesalerId;
            InvoiceDate = DateTime.Now;
            TotalAmount = 0;
        }
        public PurchasedInvoice(int invoiceId, int wholesalerId,List<PurchasedItem> Lineitems)
        {
            InvoiceId = invoiceId;
            WholesalerId = wholesalerId;
            PurchasedItems = Lineitems;
            InvoiceDate= DateTime.Now;
            TotalAmount = CalculateTotal();
        }

      
        private double CalculateTotal()
        {
            return TotalAmount = PurchasedItems.Sum(item => item.TotalPrice);
        }
    }
}
