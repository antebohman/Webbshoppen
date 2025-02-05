using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF.Models
{
    internal class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalCost { get; set; }

        public int PaymentMethodId { get; set; }
        

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
