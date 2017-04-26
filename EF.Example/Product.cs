using API.Generation.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF.Example {

    public class Product {

        public Product() {
            Campaigns = new List<Campaign>();
        }

        [Key]
        public Guid OurProductId { get; set; }

        [MaxLength(128)]
        public string TheirProductId { get; set; }

        [ApiExposedResourceProperty]
        [MaxLength(512)]
        public string Name { get; set; }

        [ApiExposedResourceProperty]
        public decimal WholesalePrice { get; set; }

        [ApiExposedResourceProperty]
        public virtual ICollection<Campaign> Campaigns { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

    }

}
