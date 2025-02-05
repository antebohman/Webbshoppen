using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF.Models
{
    internal class PaymentCard
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public string? CardNumber { get; set; }

        public string CardType { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
