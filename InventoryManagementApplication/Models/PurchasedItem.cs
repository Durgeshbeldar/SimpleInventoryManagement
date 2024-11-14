using InventoryManagementApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    internal class PurchasedItem : LineItem
    {
        [ForeignKey("PurchasedInvoice")]
        public int InvoiceId { get; set; }

        public PurchasedItem() : base()
        {
        }
        public PurchasedItem(Product product, int quantity) : base(product, quantity)
        {
        }

        public override double GetTotalPrice()
        {
            return Product.PurchasedPrice * Quantity;
        }

    }
}
