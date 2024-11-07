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

        public Stock() { }
        public Stock(int productId, int initialQuantity, DateTime lastUpdated)
        {
            ProductId = productId;
            AvailableQuantity = initialQuantity;
            LastUpdated = lastUpdated;
        }
    }
}
