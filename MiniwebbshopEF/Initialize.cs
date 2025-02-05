using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using MiniwebbshopEF.Models;

namespace MiniwebbshopEF
{
    internal class Initialize
    {
        public static void InitializeDatabase()
        {
            using (var context = new MyDbContext())
            {
                //  Skapa kunder
                var customers = new List<Customer>
        {
            new Customer { Name = "Anna Andersson", Address = "Västra gatan 12", City = "Stockholm", Country = "Sverige", Age = 30 },
            new Customer { Name = "Johan Svensson", Address = "Östra gatan 5", City = "Göteborg", Country = "Sverige", Age = 25 },
            new Customer { Name = "Lisa Karlsson", Address = "Södra vägen 10", City = "Malmö", Country = "Sverige", Age = 28 },
            new Customer { Name = "Erik Berg", Address = "Norrbackagatan 8", City = "Uppsala", Country = "Sverige", Age = 35 },
            new Customer { Name = "Emma Lind", Address = "Lundavägen 3", City = "Lund", Country = "Sverige", Age = 22 },
            new Customer { Name = "Oskar Nilsson", Address = "Helsingborgsvägen 15", City = "Helsingborg", Country = "Sverige", Age = 40 },
            new Customer { Name = "Sofia Ek", Address = "Gävlegatan 22", City = "Gävle", Country = "Sverige", Age = 29 },
            new Customer { Name = "Daniel Holm", Address = "Boråsvägen 7", City = "Borås", Country = "Sverige", Age = 33 }
        };
                context.Customers.AddRange(customers);
                context.SaveChanges();

                //  Skapa kategorier
                var categories = new List<Category>
        {
            new Category { CategoryName = "Budget" },
            new Category { CategoryName = "Casual" },
            new Category { CategoryName = "Pro" }
        };
                context.Categories.AddRange(categories);
                context.SaveChanges();


                //  Skapa leverantörer
                var suppliers = new List<Supplier>
        {
            new Supplier { SupplierName = "TechOne" },
            new Supplier { SupplierName = "GamerWorld" },
            new Supplier { SupplierName = "EliteGear" }
        };
                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();

                //  Skapa produkter
                var products = new List<Product>
        {
            // Budget
            new Product { ProductName = "Budget Skärm 24\"", Price = 1499, Description = "En enkel 24-tumsskärm.", IsFeatured = false, CategoryId = categories[0].Id, SupplierId = suppliers[0].Id },
            new Product { ProductName = "Budget Tangentbord", Price = 499, Description = "Ett prisvärt tangentbord.", IsFeatured = false, CategoryId = categories[0].Id, SupplierId = suppliers[0].Id },
           new Product { ProductName = "Budget Gaming Mus", Price = 299, Description = "En basic gaming-mus.", IsFeatured = false, CategoryId = categories[0].Id, SupplierId = suppliers[1].Id },
            new Product { ProductName = "Budget Headset", Price = 699, Description = "Enkel ljudkvalitet.", IsFeatured = false, CategoryId = categories[0].Id, SupplierId = suppliers[1].Id },
            new Product { ProductName = "Budget Skärm 27\"", Price = 1799, Description = "En större 27-tumsskärm.", IsFeatured = false, CategoryId = categories[0].Id, SupplierId = suppliers[2].Id },

            // Casual
            new Product { ProductName = "Casual Skärm 27\"", Price = 2499, Description = "27\" med 75Hz uppdateringsfrekvens.", IsFeatured = false, CategoryId = categories[1].Id, SupplierId = suppliers[0].Id },
            new Product { ProductName = "Casual Tangentbord", Price = 999, Description = "Mekaniskt tangentbord.", IsFeatured = false, CategoryId = categories[1].Id, SupplierId = suppliers[1].Id },
            new Product { ProductName = "Casual Gaming Mus", Price = 699, Description = "Snabb respons, bra grepp.", IsFeatured = false, CategoryId = categories[1].Id, SupplierId = suppliers[2].Id },
           new Product { ProductName = "Casual Headset", Price = 1299, Description = "Bra ljud & brusreducering.", IsFeatured = false, CategoryId = categories[1].Id, SupplierId = suppliers[1].Id },
            new Product { ProductName = "Casual Skärm 32\"", Price = 3499, Description = "Större skärm för bättre upplevelse.", IsFeatured = false, CategoryId = categories[1].Id, SupplierId = suppliers[2].Id },

            // Pro
            new Product { ProductName = "Pro Skärm 32\" 144Hz", Price = 5999, Description = "144Hz för proffs.", IsFeatured = false, CategoryId = categories[2].Id, SupplierId = suppliers[0].Id },
            new Product { ProductName = "Pro Tangentbord RGB", Price = 1599, Description = "Mekaniskt tangentbord med RGB.", IsFeatured = false, CategoryId = categories[2].Id, SupplierId = suppliers[1].Id },
            new Product { ProductName = "Pro Gaming Mus", Price = 1199, Description = "Optimerad för e-sport.", IsFeatured = false, CategoryId = categories[2].Id, SupplierId = suppliers[2].Id },
            new Product { ProductName = "Pro Headset", Price = 2499, Description = "Högklassigt ljud för gaming.", IsFeatured = false, CategoryId = categories[2].Id, SupplierId = suppliers[1].Id },
            new Product { ProductName = "Pro Skärm 34\" Ultrawide", Price = 7999, Description = "Perfekt för multitasking & gaming.", IsFeatured = false, CategoryId = categories[2].Id, SupplierId = suppliers[2].Id }
        };
                context.Products.AddRange(products);
                context.SaveChanges();

                //Skapa betalningsalternativ
                var paymentMethods = new List<PaymentMethod>
                {
                   new PaymentMethod { MethodName = "Kreditkort" },
                   new PaymentMethod { MethodName = "Swish" },
                   new PaymentMethod { MethodName = "Faktura" }
                };
                context.PaymentMethods.AddRange(paymentMethods);
                context.SaveChanges();

                //Skapa leveransalternativ

                var deliveryOptions = new List<DeliveryOption>
                {
                   new DeliveryOption { DeliveryOptionName = "Standardfrakt", DeliveryPrice = 49 },
                   new DeliveryOption { DeliveryOptionName = "Expressfrakt", DeliveryPrice = 99 },
                   new DeliveryOption { DeliveryOptionName = "Hämta i butik", DeliveryPrice = 0 }
                };
                context.DeliveryOptions.AddRange(deliveryOptions);
                context.SaveChanges();

            }
        }
    }
}
