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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceId { get; set; }

        [ForeignKey("Wholesaler")]
        public int WholesalerId { get; set; }

        public List<PurchasedItem> LineItems {  get; set; }
        public DateTime InvoiceDate { get; set; }  
        
        public double TotalAmount { get; set; }

        public Wholesaler Wholesaler { get; set; }

        public PurchasedInvoice()
        {
            LineItems = new List<PurchasedItem>();
        }
        public PurchasedInvoice(int wholesalerId, List<PurchasedItem> lineItems)
        {
            InvoiceId = GenerateInvoiceId();
            WholesalerId = wholesalerId;
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

        public override string ToString()
        {
            StringBuilder invoiceBuilder = new StringBuilder();

            invoiceBuilder.AppendLine("****************** PURCHASED INVOICE ******************");
            invoiceBuilder.AppendLine($"Invoice ID: {InvoiceId}".PadRight(50));
            invoiceBuilder.AppendLine($"Date: {InvoiceDate.ToString("dd-MM-yyyy")}".PadRight(50));
            invoiceBuilder.AppendLine($"Wholesaler: {Wholesaler.Name}".PadRight(50));
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
