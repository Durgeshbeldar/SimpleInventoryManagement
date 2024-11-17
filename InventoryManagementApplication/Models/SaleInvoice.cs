using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace InventoryManagementApplication.Models
{
    internal class SaleInvoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public List<SaleItem> SaleItems { get; set; }
        public double TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }

        public Customer Customer { get; set; }

        public SaleInvoice()
        {
           SaleItems = new List<SaleItem>();
        }
        public SaleInvoice(int customerId)
        {
            CustomerId = customerId; 
            InvoiceDate = DateTime.Now;
            TotalAmount = 0;
        }
        public SaleInvoice(int invoiceId, int customerId, List<SaleItem> lineItems)
        {
            InvoiceId = invoiceId;
            CustomerId = customerId;
            SaleItems = lineItems;
            InvoiceDate = DateTime.Now;
            TotalAmount = CalculateTotal();
        }

        private double CalculateTotal()
        {
            return TotalAmount = SaleItems.Sum(item => item.TotalPrice);
        }
    }
}
