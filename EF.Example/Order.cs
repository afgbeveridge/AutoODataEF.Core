using API.Generation.Support;
using System;
using System.Collections.Generic;

namespace EF.Example {

    public class Order {

        public Order() {
            OrderLines = new List<OrderLine>();
        }

        public int OrderId { get; set; }

        [ApiExposedResourceProperty]
        public DateTime Placed { get; set; }

        public DateTime? Shipped { get; set; }

        public decimal Total { get; set; }

        [ApiExposedResourceProperty]
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public Customer Customer { get; set; }

    }

}
