using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF.Models
{
    internal class Supplier
    {
        public int Id { get; set; }

        public string? SupplierName { get; set; }       

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
