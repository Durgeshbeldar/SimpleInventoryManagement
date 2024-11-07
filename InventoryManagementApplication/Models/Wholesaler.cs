using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    internal class Wholesaler
    {
        [Key]
        public int WholesalerId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address   { get; set; }

        public override string ToString()
        {
            return $"\nWholesaler Name : {Name} | ID : {WholesalerId}\n" +
                $"Phone Number : {ContactNumber}\n" +
                $"Address : {Address}\n";
        }
    }
}
