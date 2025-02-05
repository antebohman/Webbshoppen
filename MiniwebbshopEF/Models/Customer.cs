using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF.Models
{
    internal class Customer
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<PaymentCard> PaymentCards { get; set; } = new List<PaymentCard>();


    }
}
