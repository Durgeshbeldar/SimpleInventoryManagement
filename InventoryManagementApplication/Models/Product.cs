using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    internal class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double PurchasedPrice { get; set; }
        public double MRP { get; set; } // This is an Selling Price For Customer

        public Category Category { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
    }
}
