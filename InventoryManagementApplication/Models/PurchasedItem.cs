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
        [ForeignKey("InvoiceId")]
        public int InvoiceId { get; set; }
        public PurchasedInvoice? PurchasedInvoice { get; set; }
        public PurchasedItem() : base()
        {
        }
        public PurchasedItem(int productId, int quantity , double totalPrice) : base(productId, quantity, totalPrice)
        {
        }
    }
}
