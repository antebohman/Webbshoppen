using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF.Models
{
    internal class AdminTest
    {
        public static void ShowAdminMenu()
        {
            while (true)
            {
                
                Console.Clear();
                List<string> topText = new List<string> { "# Gaming butiken #", "Allt inom gaming" };
                var windowTop = new Window("", 2, 1, topText);
                windowTop.Draw();
                List<string> topText4 = new List<string> {
                "1. Lägg till produkt",
                "2. Uppdatera produkt",
                "3. Ta bort produkt",
                "4. Lägg till kategori",
                "5. Uppdatera kategori",
                "6. Ta bort kategori",
                "7. Uppdatera kund",
                "8. Ta bort kund",
                "9. Visa alla produkter",
                "10. Visa alla kunder",
                "11. Avsluta",
                "12. Visa Statistik"};
                var windowTop4 = new Window("Adminpanel", 70, 15, topText4);
                windowTop4.Draw();

                Console.Write("Välj ett alternativ: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("Produktnamn: ");
                            string name = Console.ReadLine();
                            Console.Write("Beskrivning: ");
                            string description = Console.ReadLine();
                            Console.Write("Pris: ");
                            decimal price = decimal.Parse(Console.ReadLine());
                            Console.Write("Kategori-ID: ");
                            int categoryId = int.Parse(Console.ReadLine());
                            Console.Write("Leverantörs-ID: ");
                            int supplierId = int.Parse(Console.ReadLine());
                            AddProduct(name, description, price, categoryId, supplierId);
                            break;

                        case "2":
                            Console.Clear();
                            Console.Write("Produkt-ID: ");
                            int productId = int.Parse(Console.ReadLine());
                            Console.Write("Nytt namn: ");
                            string newName = Console.ReadLine();
                            Console.Write("Ny beskrivning: ");
                            string newDescription = Console.ReadLine();
                            Console.Write("Nytt pris: ");
                            decimal newPrice = decimal.Parse(Console.ReadLine());
                            Console.Write("Ny kategori-ID: ");
                            int newCategoryId = int.Parse(Console.ReadLine());
                            Console.Write("Ny leverantörs-ID: ");
                            int newSupplierId = int.Parse(Console.ReadLine());
                            UpdateProduct(productId, newName, newDescription, newPrice, newCategoryId, newSupplierId);
                            break;

                        case "3":
                            Console.Clear();
                            Console.Write("Produkt-ID att ta bort: ");
                            int deleteProductId = int.Parse(Console.ReadLine());
                            DeleteProduct(deleteProductId);
                            break;

                        case "4":
                            Console.Clear();
                            Console.Write("Kategori namn: ");
                            string categoryName = Console.ReadLine();
                            AddCategory(categoryName);
                            break;

                        case "5":
                            Console.Clear();
                            Console.Write("Kategori-ID: ");
                            int updateCategoryId = int.Parse(Console.ReadLine());
                            Console.Write("Nytt namn: ");
                            string newCategoryName = Console.ReadLine();
                            UpdateCategory(updateCategoryId, newCategoryName);
                            break;

                        case "6":
                            Console.Clear();
                            Console.Write("Kategori-ID att ta bort: ");
                            int deleteCategoryId = int.Parse(Console.ReadLine());
                            DeleteCategory(deleteCategoryId);
                            break;

                        case "7":
                            Console.Clear();
                            Console.Write("Kund-ID: ");
                            int customerId = int.Parse(Console.ReadLine());
                            Console.Write("Nytt namn: ");
                            string customerName = Console.ReadLine();
                            Console.Write("Ny adress: ");
                            string address = Console.ReadLine();
                            Console.Write("Ny stad: ");
                            string city = Console.ReadLine();
                            Console.Write("Nytt land: ");
                            string country = Console.ReadLine();
                            Console.Write("Ny ålder: ");
                            int age = int.Parse(Console.ReadLine());
                            UpdateCustomer(customerId, customerName, address, city, country, age);
                            break;

                        case "8":
                            Console.Clear();
                            Console.Write("Kund-ID att ta bort: ");
                            int deleteCustomerId = int.Parse(Console.ReadLine());
                            DeleteCustomer(deleteCustomerId);
                            break;

                        case "9":
                            Console.Clear();
                            ShowAllProducts();
                            Console.Write("Tryck enter för att återgå...");
                            Console.ReadLine();
                            break;

                        case "10":
                            Console.Clear();
                            ShowAllCustomers();
                            Console.Write("Tryck enter för att återgå...");
                            Console.ReadLine();
                            break;

                        case "11":
                            Console.WriteLine("Avslutar admin-menyn...");
                            return;

                            case "12":
                                ShowStatistics();
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ett fel uppstod: " + ex.Message);
                }
            }
        }

        public static void ShowAllProducts()
        {
            using (var context = new MyDbContext())
            {
                var products = context.Products
            .Select(p => new
            {
                p.Id,
                p.ProductName,
                p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.CategoryName
            })
            .ToList();
                foreach (var product in products)
                {
                    Console.WriteLine("ID: " + product.Id + ", Namn: " + product.ProductName + "Pris: " + product.Price + " Kategori: " + product.CategoryName + " ID: " + product.CategoryId);
                }
            }
        }

        public static void ShowAllCustomers()
        {
            using (var context = new MyDbContext())
            {
                var customers = context.Customers.ToList();
                foreach (var customer in customers)
                {
                    Console.WriteLine("ID: " + customer.Id + "Namn: " + customer.Name + "Stad: " + customer.City);
                }
            }
        }

        // Lägg till produkt
        private static void AddProduct(string name, string description, decimal price, int categoryId, int supplierId)
        {
            using (var context = new MyDbContext())
            {
                var product = new Product
                {
                    ProductName = name,
                    Description = description,
                    Price = price,
                    CategoryId = categoryId,
                    SupplierId = supplierId
                };
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        //Uppdatera produkt
        private static void UpdateProduct(int productId, string newName, string newDescription, decimal newPrice, int newCategoryId, int newSupplierId)
        {
            using (var context = new MyDbContext())
            {
                var product = context.Products.Find(productId);
                if (product != null)
                {
                    product.ProductName = newName;
                    product.Description = newDescription;
                    product.Price = newPrice;
                    product.CategoryId = newCategoryId;
                    product.SupplierId = newSupplierId;
                    context.SaveChanges();
                }
            }
        }

        private static void DeleteProduct(int productId)
        {
            using (var context = new MyDbContext())
            {
                var product = context.Products.Find(productId);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
        }

        private static void AddCategory(string categoryName)
        {
            using (var context = new MyDbContext())
            {
                var category = new Category
                {
                    CategoryName = categoryName
                };
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        private static void UpdateCategory(int categoryId, string newCategoryName)
        {
            using (var context = new MyDbContext())
            {
                var category = context.Categories.Find(categoryId);
                if (category != null)
                {
                    category.CategoryName = newCategoryName;
                    context.SaveChanges();
                }
            }
        }

        private static void DeleteCategory(int categoryId)
        {
            using (var context = new MyDbContext())
            {
                var category = context.Categories.Find(categoryId);
                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
        }

        private static void UpdateCustomer(int customerId, string customerName, string address, string city, string country, int age)
        {
            using (var context = new MyDbContext())
            {
                var customer = context.Customers.Find(customerId);
                if (customer != null)
                {
                    customer.Name = customerName;
                    customer.Address = address;
                    customer.City = city;
                    customer.Country = country;
                    customer.Age = age;
                    context.SaveChanges();
                }
            }
        }

        private static void DeleteCustomer(int customerId)
        {
            using (var context = new MyDbContext())
            {
                var customer = context.Customers.Find(customerId);
                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            }
        }
        public static void ShowStatistics()
        {
            using (var context = new MyDbContext())
            {
                Console.Clear();
                Console.WriteLine("--- Statistik ---\n");

                // 1. Flest beställningar per stad
                var ordersPerCity = context.Orders
                    .GroupBy(o => o.Customer.City)
                    .Select(g => new { City = g.Key, Count = g.Count() })
                    .OrderByDescending(g => g.Count)
                    .FirstOrDefault();
                Console.WriteLine("Flest beställningar kommer från: " + (ordersPerCity?.City ?? "Ingen data") + " (" + (ordersPerCity != null ? ordersPerCity.Count.ToString() : "0") + " beställningar)\n");

                // 2. Populäraste produkten
                var popularProduct = context.OrderDetails
                    .GroupBy(od => od.ProductId)
                    .Select(g => new { ProductId = g.Key, Count = g.Sum(od => od.Quantity) })
                    .OrderByDescending(g => g.Count)
                    .FirstOrDefault();
                var productName = context.Products.Find(popularProduct?.ProductId)?.ProductName ?? "Ingen data";
                Console.WriteLine("Mest sålda produkten: " + productName + " (" + (popularProduct != null ? popularProduct.Count.ToString() : "0") + " sålda)\n");

                // 3. Populäraste kategorin
                var popularCategory = context.OrderDetails
                    .Join(context.Products, od => od.ProductId, p => p.Id, (od, p) => new { od, p.CategoryId })
                    .GroupBy(p => p.CategoryId)
                    .Select(g => new { CategoryId = g.Key, Count = g.Sum(p => p.od.Quantity) })
                    .OrderByDescending(g => g.Count)
                    .FirstOrDefault();
                var categoryName = context.Categories.Find(popularCategory?.CategoryId)?.CategoryName ?? "Ingen data";
                Console.WriteLine("Mest sålda kategorin: " + categoryName + " (" + (popularCategory != null ? popularCategory.Count.ToString() : "0") + " sålda)\n");



                // 4. Vilken leverantörs produkter säljs mest
                var bestSupplier = context.OrderDetails
                    .Join(context.Products, od => od.ProductId, p => p.Id, (od, p) => new { od, p.SupplierId })
                    .GroupBy(p => p.SupplierId)
                    .Select(g => new { SupplierId = g.Key, Count = g.Sum(p => p.od.Quantity) })
                    .OrderByDescending(g => g.Count)
                    .FirstOrDefault();
                var supplierName = context.Suppliers.Find(bestSupplier?.SupplierId)?.SupplierName ?? "Ingen data";
                Console.WriteLine("Bäst säljande leverantör: " + supplierName + " (" + (bestSupplier != null ? bestSupplier.Count.ToString() : "0") + " sålda)\n");
            }

            Console.Write("Tryck enter för att återgå...");
            Console.ReadLine();
        }
    }
}
