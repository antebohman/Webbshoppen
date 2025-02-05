using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF.Models
{
    internal class DeliveryOption
    {
        public int Id { get; set; }
        public string DeliveryOptionName { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
