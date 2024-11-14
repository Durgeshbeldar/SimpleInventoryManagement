using InventoryManagementApplication.Interfaces;
using InventoryManagementApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.Data
{
    internal class InventoryContext : DbContext
    {
        string ConnString = ConfigurationManager.AppSettings["ConnString"];
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet<PurchasedInvoice> PurchasedInvoices { get; set; }
        public DbSet<SaleInvoice> SaleInvoices { get; set; }

        public DbSet<PurchasedItem> PurchasedItems { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

       
        public DbSet<Stock> InventoryStocks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnString);
        }
    }
}
