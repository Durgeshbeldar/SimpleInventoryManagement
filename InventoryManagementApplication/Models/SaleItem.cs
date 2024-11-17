using InventoryManagementApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    internal class SaleItem : LineItem
    {
        [ForeignKey("SaleInvoice")]
        public int InvoiceId { get; set; }
        public SaleInvoice? SaleInvoice { get; set; }
        public SaleItem() : base()
        {

        }
        public SaleItem(int product, int quantity, double totalPrice) : base(product, quantity, totalPrice) { }
    }
}
