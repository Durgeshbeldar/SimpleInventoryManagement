using InventoryManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Interfaces
{
    internal abstract class LineItem
    {
        [Key]
        public int ItemId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public LineItem() { }   
        public LineItem(Product product, int quantity)
        {
            Product = product;
            ProductId = product.ProductId;
            Quantity = quantity;
            TotalPrice = GetTotalPrice();
        }

        public virtual double GetTotalPrice()
        {
            return 0;
        }
    }
}
