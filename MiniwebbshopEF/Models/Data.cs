using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF.Models
{
    internal class Data
    {
        public static async Task Run()
        {

            using (var context = new MyDbContext())
            {
                var random = new Random();
                var customers = context.Customers.ToList();
                var products = context.Products.ToList();
                var paymentMethods = context.PaymentMethods.ToList();
                var deliveryOptions = context.DeliveryOptions.ToList();
                var paymentCards = context.PaymentCards.ToList();

                var orders = new List<Order>();
                var orderDetails = new List<OrderDetail>();

                foreach (var customer in customers)
                {
                    var selectedPaymentMethod = paymentMethods[random.Next(paymentMethods.Count)];
                    var order = new Order
                    {
                        CustomerId = customer.Id,
                        OrderDate = DateTime.Now.AddDays(-random.Next(1, 30)),
                        PaymentMethodId = selectedPaymentMethod.Id,
                        TotalCost = 0  // Uppdateras senare
                    };

                    await context.Orders.AddAsync(order);
                    await context.SaveChangesAsync(); // Spara order först för att få OrderId

                    decimal totalCost = 0;
                    int productCount = random.Next(1, 5); // Varje order får 1-4 produkter
                    var selectedProducts = products.OrderBy(x => random.Next()).Take(productCount).ToList();

                    foreach (var product in selectedProducts)
                    {
                        var quantity = random.Next(1, 4); // 1-3 av varje produkt
                        var subtotal = (product.Price ?? 0) * quantity;

                        orderDetails.Add(new OrderDetail
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Quantity = quantity,
                            SubTotal = subtotal
                        });

                        totalCost += subtotal;
                    }

                    var deliveryOption = deliveryOptions[random.Next(deliveryOptions.Count)];
                    order.TotalCost = totalCost + deliveryOption.DeliveryPrice;

                    // Om betalningsmetoden är kreditkort, välj eller skapa ett betalkort
                    if (selectedPaymentMethod.MethodName == "Kreditkort")
                    {
                        var customerCard = paymentCards.FirstOrDefault(pc => pc.CustomerId == customer.Id);
                        if (customerCard == null)
                        {
                            customerCard = new PaymentCard
                            {
                                CustomerId = customer.Id,
                                CardNumber = GenerateRandomCardNumber(),
                                CardType = "Visa", // Kan slumpas
                                ExpiryDate = DateTime.UtcNow.AddYears(2)
                            };
                            context.PaymentCards.Add(customerCard);
                            context.SaveChanges();
                        }
                    }

                    orders.Add(order);
                }

                context.OrderDetails.AddRange(orderDetails);
                context.SaveChanges();
            }
        }

        private static string GenerateRandomCardNumber()
        {
            Random random = new Random();
            string cardNumber = "4"; 
            for (int i = 0; i < 15; i++)
            {
                cardNumber += random.Next(0, 10).ToString();
            }
            return cardNumber;




        }
    }
}










  
