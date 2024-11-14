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
        public SaleItem() : base()
        {

        }
        public SaleItem(Product product, int quantity) : base(product, quantity) { }
     
        public override double GetTotalPrice()
        {
            return Product.MRP * Quantity;
        }

    }
}
