using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF.Models
{
    internal class PaymentMethod
    {
        public int Id { get; set; }
        public string MethodName { get; set; } //Lägg till swish
    }
}
