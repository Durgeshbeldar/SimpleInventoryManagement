using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    internal class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int AvailableQuantity { get; set; }
        public int TotalSold { get; set; }
        public int TotalPurchased { get; set; }
        public DateTime LastUpdated { get; set; }
        public Product Product { get; set; }
        public Stock() { }
        public Stock(int productId)
        {
            ProductId = productId;
            AvailableQuantity = 0;
            LastUpdated = DateTime.Now;
            TotalPurchased = 0;
            TotalSold = 0;
        }
    }
}
