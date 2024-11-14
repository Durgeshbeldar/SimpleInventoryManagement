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

        public List<SaleItem> LineItems { get; set; }
        public double TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }

        public Customer Customer { get; set; }

        public SaleInvoice()
        {
            LineItems = new List<SaleItem>();
        }

        public SaleInvoice(int customerId, List<SaleItem> lineItems)
        {
            CustomerId = customerId;
            LineItems = lineItems;
            InvoiceDate = DateTime.Now;
            TotalAmount = CalculateTotal();
        }

        private double CalculateTotal()
        {
            return TotalAmount = LineItems.Sum(item => item.TotalPrice);
        }

        public override string ToString()
        {
            StringBuilder invoiceBuilder = new StringBuilder();

            invoiceBuilder.AppendLine("****************** SALES INVOICE ******************");
            invoiceBuilder.AppendLine($"Invoice ID: {InvoiceId}".PadRight(50));
            invoiceBuilder.AppendLine($"Date: {InvoiceDate.ToString("dd-MM-yyyy")}".PadRight(50));
            invoiceBuilder.AppendLine($"Customer: {Customer.Name}".PadRight(50));
            invoiceBuilder.AppendLine("--------------------------------------------------------");
            invoiceBuilder.AppendLine("Product Name".PadRight(25) + "Quantity".PadRight(15) + "Price".PadLeft(10));
            invoiceBuilder.AppendLine("--------------------------------------------------------");

            foreach (var item in LineItems)
            {
                invoiceBuilder.AppendLine($"{item.Product.Name.PadRight(25)}{item.Quantity.ToString().PadRight(15)}{item.TotalPrice.ToString("F2").PadLeft(10)}");
            }

            invoiceBuilder.AppendLine("--------------------------------------------------------");
            invoiceBuilder.AppendLine($"Total Amount: {TotalAmount.ToString("F2").PadLeft(50)}");
            invoiceBuilder.AppendLine("*******************************************************");

            return invoiceBuilder.ToString();
        }
    }
}
