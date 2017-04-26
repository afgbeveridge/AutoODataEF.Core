using API.Generation.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF.Example {

    public enum Rating { Low, Medium, High, Priority }

    public class Supplier {

        public int SupplierId { get; set; }

        [ApiExposedResourceProperty]
        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Address { get; set; }

        [ApiExposedResourceProperty]
        public Rating Rating { get; set; }

        [ApiExposedResourceProperty]
        public virtual ICollection<Product> ProductsSupplied { get; set; }

    }

}
