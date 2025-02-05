using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MiniwebbshopEF.Models
{
    internal class MyDbContext : DbContext
    {
       
        public DbSet<DeliveryOption> DeliveryOptions { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
    }
}
