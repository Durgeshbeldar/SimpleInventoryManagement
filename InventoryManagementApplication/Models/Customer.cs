using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    internal class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"\nCustomer Name : {Name} | ID : {CustomerId}\n" +
                $"Phone Number : {ContactNumber}\n" +
                $"Address : {Address}\n";
        }

    }
}
