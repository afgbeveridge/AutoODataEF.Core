using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Generation.Support;

namespace EF.Example {

    public class Customer {

        public Customer() {
            Orders = new List<Order>();
        }

        public int CustomerId { get; set; }

        [ApiExposedResourceProperty]
        [MaxLength(128)]
        public string Name { get; set; }

        [ApiNullifyOnCreate]
        [ApiExposedResourceProperty]
        public virtual ICollection<Order> Orders { get; set; }

    }

}
