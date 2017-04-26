using System;

namespace API.Generation.Discovery {

    public class ResourceProperty {
        public string Name { get; set; }
        public Type Type { get; set; }
        public bool IsNavigationProperty { get; set; }
    }
}
