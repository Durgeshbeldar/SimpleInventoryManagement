using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    internal class SaleInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }  
        public List<SaleItem> LineItems { get; set; }
        public double TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }

        public Customer Customer { get; set; }

        public SaleInvoice()
        {
            LineItems = new List<SaleItem>();
        }
        public SaleInvoice(int customerId, List<SaleItem>lineItems) 
        {
            InvoiceId = GenerateInvoiceId();
            CustomerId = customerId;
            LineItems = lineItems;
            InvoiceDate = DateTime.Now;
            TotalAmount = CalculateTotal();
        }

        public int GenerateInvoiceId()
        {
            Random random = new Random();
            return random.Next(1000000, 9999999);
        }

        private double CalculateTotal()
        {
            return TotalAmount = LineItems.Sum(item => item.TotalPrice);
        }

    }



}
