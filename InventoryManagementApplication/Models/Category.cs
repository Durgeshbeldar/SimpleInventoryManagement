using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    internal class Category
    {
        [Key]
        public int CategoryId { get; set; } 
        
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Category ID : {CategoryId}\n" +
                $"Category Name : {Name}\n";
        }
    }
}
