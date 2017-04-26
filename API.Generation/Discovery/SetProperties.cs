using System;
using System.Collections.Generic;
using System.Text;

namespace API.Generation.Discovery {

    public class SetProperties {

        public Type EntityType { get; set; }

        public IEnumerable<Attribute> Attributes { get; set; }

        public string Name { get; set; }

    }

}
