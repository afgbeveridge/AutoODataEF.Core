using System;
using System.Collections.Generic;

namespace API.Generation.Discovery {

    public class ControllerModel {

        public string ResourceCollectionName { get; set; }

        public Type ResourceIdType { get; set; }

        public string KeyName { get; set; }

        public IEnumerable<ResourceProperty> ExposedProperties { get; set; }

        public SetProperties Properties { get; set; }

        public IEnumerable<PropertyDirectives> Directives { get; set; }

    }

}
