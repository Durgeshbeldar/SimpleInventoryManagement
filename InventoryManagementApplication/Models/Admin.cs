using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Models
{
    internal class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password  { get; set; }

        public Admin(string userId, string name, string password)
        {
            UserId = userId;
            Name = name;
            Password = password;
        }
        public override string ToString()
        {
            return $"Admin Details :\n" +
                $"Admin Name : {Name}\n" +
                $"Password : {Password}\n";
        }
    }
}
