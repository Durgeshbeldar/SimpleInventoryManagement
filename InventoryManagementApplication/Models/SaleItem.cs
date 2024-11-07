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
        public SaleItem() : base()
        {

        }
        public SaleItem(Product product, int quantity) : base(product, quantity) { }
     
       public override string ToString()
       {
           return $"\n Product Name : {Product.Name}  |  Quantity : {Quantity}  |  Price : {TotalPrice}\n";
       }

        public override double GetTotalPrice()
        {
            return Product.MRP * Quantity;
        }

    }
}
