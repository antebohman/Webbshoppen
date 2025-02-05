using MiniwebbshopEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF
{
    internal class CustomerPanel
    {
        private static List<OrderDetail> cart = new List<OrderDetail>();

        public static void ShowShopMenu()
        {
            while (true)
            {
                //Menyn
                Console.Clear();
                List<string> topText = new List<string> { "# Gaming Butiken #", "Allt inom gaming" };
                var windowTop = new Window("", 2, 1, topText);
                windowTop.Draw();
                List<string> topText2 = new List<string> { "143 st Casual Skärm 32'", "78 st Pro Gaming Mus", "56 st Budget Skärm 27'", "11 st Casual Headsets" };
                var windowTop2 = new Window("Bäst säljande produkter", 2, 15, topText2);
                windowTop2.Draw();

                List<string> topText3 = new List<string> { 
                "1. Visa kategorier och produkter",
                  "2. Sök efter produkt",
                  "3. Visa varukorg",
                  "4. Töm varukorg",
                  "5. Gå till kassan",
                  "6. Adminpanel",
                  "7. Avsluta" };
                var windowTop3 = new Window("Kundmeny", 40, 15, topText3);
                windowTop3.Draw();
                

                Console.Write("Välj ett alternativ:");
                string choice = Console.ReadLine();
                //Menyval
                switch (choice)
                {
                    case "1":
                        ShowCategoriesAndProducts();
                        break;
                    case "2":
                        SearchProduct();
                        
                        break;
                    case "3":
                        ShowCart();
                        break;
                    case "4":
                        ClearCart();
                        break;
                    case "5":
                        Checkout();
                        break;
                    case "6":
                        AdminTest.ShowAdminMenu();
                        break;
                    case "7":
                        Console.WriteLine("Avslutar webbshoppen...");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }
        //Metod för att visa kategorier och produkter
        private static void ShowCategoriesAndProducts()
        {
            using (var context = new MyDbContext())
            {
                var categories = context.Categories.ToList();
                foreach (var category in categories)
                {
                    Console.WriteLine("\nKategori: " + category.CategoryName);
                    var products = context.Products.Where(p => p.CategoryId == category.Id).ToList();//Hämtar produkter från databasen
                    foreach (var product in products)
                    {
                        Console.WriteLine("ID: " + product.Id + " - " + product.ProductName + " (" + product.Price + " kr)");//Utskrivning av produkter
                    }
                }
                
            }
            
            Console.Write("Ange produkt-ID för att lägga till i varukorgen eller tryck enter för att återgå: ");//Lägger till i varukorgen
            string input = Console.ReadLine();
            if (int.TryParse(input, out int productId))
            {
                AddToCart(productId);
            }
        }
        //Metod för att söka efter produkt
        private static void SearchProduct()
        {
            Console.Write("Ange sökord: ");
            string search = Console.ReadLine().ToLower();

            using (var context = new MyDbContext())
            {
                var results = context.Products.Where(p => p.ProductName.ToLower().Contains(search)).ToList();//Letar i databasen

                if (!results.Any())
                {
                    Console.WriteLine("Inga produkter hittades.");//Om inga produkter med det namnet hittas
                }
                else
                {
                    Console.WriteLine("\nSökresultat:");
                    foreach (var product in results)
                    {
                        Console.WriteLine("ID: " + product.Id + " - " + product.ProductName + " (" + product.Price.ToString() + " kr)");//Skriver ut produkt tillsammans med pris
                    }
                }
            }
            Console.Write("Ange produkt-ID för att lägga till i varukorgen eller tryck enter för att återgå: ");//Välj produkt att lägga till i varukorgen
            string input = Console.ReadLine();
            if (int.TryParse(input, out int productId))
            {
                AddToCart(productId);
            }
        }
        //Metod för att lägga till i varukorgen
        private static void AddToCart(int productId)
        {
            using (var context = new MyDbContext())
            {
                var product = context.Products.Find(productId);
                if (product != null)
                {
                    Console.Write("Ange antal: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)//Kvantitet
                    {
                        cart.Add(new OrderDetail { Product = product, Quantity = quantity, SubTotal = product.Price * quantity });
                        Console.WriteLine(product.ProductName + " (" + quantity.ToString() + " st) har lagts till i varukorgen.");
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt antal.");
                    }
                }
                else
                {
                    Console.WriteLine("Produkten hittades inte.");
                }
            }
        }

      //Visar varukorgen
        private static void ShowCart()
        {
            List<string> cartItems = cart.Select(item =>
    item.Quantity.ToString() + " st " + item.Product.ProductName + " (" + item.SubTotal.ToString() + " kr)")
    .ToList();

            if (!cartItems.Any())
            {
                cartItems.Add("Varukorgen är tom.");
            }

            cartItems.Add("");
            var windowCart = new Window("Din varukorg", 30, 6, cartItems);
            windowCart.Draw();

            Console.Write("Tryck enter för att återgå...");
            Console.ReadLine();
        }
        //Rensar varukorgen
        private static void ClearCart()
        {
            cart.Clear();
            Console.WriteLine("Varukorgen har tömts.");
            Console.Write("Tryck enter för att återgå...");
            Console.ReadLine();
        }
        //Utcheckning
        private static void Checkout()
        {
            if (!cart.Any())
            {
                Console.WriteLine("Varukorgen är tom.");
                Console.Write("Tryck enter för att återgå...");
                Console.ReadLine();
                return;
            }

            Console.Write("Ange ditt namn: ");
            string name = Console.ReadLine();
            Console.Write("Ange din adress: ");
            string address = Console.ReadLine();
            Console.Write("Ange stad ");
            string city = Console.ReadLine();
            Console.Write("Ange land ");
            string country = Console.ReadLine();
            Console.Write("Ange ålder ");
            int age = int.Parse(Console.ReadLine());

            using (var context = new MyDbContext())
            {
                var customer = context.Customers.FirstOrDefault(c => c.Name == name && c.Address == address);
                if (customer == null)
                {
                    customer = new Customer { Name = name, Address = address, City = city, Country = country, Age = age };
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }

                Console.WriteLine("\nVälj fraktalternativ:");
                Console.WriteLine("1. Standard (49 kr)");
                Console.WriteLine("2. Express (99 kr)");
                Console.WriteLine("3. Hämta i butik (0 kr)");
                Console.Write("Ditt val: ");

                int shippingCost = Console.ReadLine() switch
                {
                    "2" => 99,
                    "3" => 0,
                    _ => 49//default switch expression
                };

                decimal total = cart.Sum(i => i.SubTotal ?? 0) + shippingCost;

                Console.WriteLine("\nTotal med frakt: " + total + " kr");
                Console.WriteLine("\nVälj betalningsmetod:");
                Console.WriteLine("1. Kort");
                Console.WriteLine("2. Swish");
                Console.WriteLine("3. Faktura");
                Console.Write("Ditt val: ");

                string paymentMethod = Console.ReadLine();//payment method
                var payment = context.PaymentMethods.FirstOrDefault(p => p.MethodName.ToLower() == paymentMethod.ToLower());
                if (payment == null)
                {
                    payment = new PaymentMethod { MethodName = paymentMethod };
                    context.PaymentMethods.Add(payment);
                    context.SaveChanges();
                }

                var order = new Order
                {
                    CustomerId = customer.Id,
                    OrderDate = DateTime.Now,
                    TotalCost = total,
                    PaymentMethodId = payment.Id
                };
                context.Orders.Add(order);
                context.SaveChanges();

                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderId = order.OrderId,
                        ProductId = item.Product.Id,
                        Quantity = item.Quantity,
                        SubTotal = item.SubTotal
                    };
                    context.OrderDetails.Add(orderDetail);
                }
                context.SaveChanges();

                Console.WriteLine("\nBetalning genomförd! Tack för ditt köp.");
                cart.Clear();
            }
            Console.Write("Tryck enter för att återgå...");
            Console.ReadLine();
        }
    }
}
