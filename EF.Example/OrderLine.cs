using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Example {

    public class OrderLine {

        public int OrderLineId { get; set; }

        public decimal Amount { get; set; }

        public decimal? Discount { get; set; }

        public Product Product { get; set; }
    }

}
