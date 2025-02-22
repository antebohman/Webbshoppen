﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF.Models
{
    internal class OrderDetail
    {
        public int Id { get; set; }

        public virtual Order Order { get; set; }

        public int OrderId { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int? Quantity { get; set; }

        public decimal? SubTotal { get; set; }

    }
}
