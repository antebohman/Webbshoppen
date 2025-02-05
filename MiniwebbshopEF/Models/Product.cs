using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF.Models
{
    internal class Product
    {

     
        //Primary key
        public int Id { get; set; }

        public string? ProductName { get; set; } 

        public decimal? Price { get; set; } 

        public string? Description { get; set; }

        public bool IsFeatured { get; set; } //Kunna visa utvalda produkten


        //Foreign key
        public int CategoryId { get; set; }

        //Navigation property
        public virtual Category Category { get; set; }

        //Foregin key
        public int SupplierId { get; set; }

        //Navigation property
        public virtual Supplier Supplier { get; set; }


        //Navigation property
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();





    }
}
