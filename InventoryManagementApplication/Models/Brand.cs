using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
       
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Brand Id : {BrandId}\n" +
                $"Brand Name : {Name}\n";
        }
    }
}
