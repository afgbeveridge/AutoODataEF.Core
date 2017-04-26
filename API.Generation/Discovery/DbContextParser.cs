using API.Generation.Support;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace API.Generation.Discovery {

    public class DbContextParser {

        private Type ContextType { get; }

        public DbContextParser(Type contextType) {
            Assert.True<InvalidOperationException>(contextType.GetTypeInfo().IsSubclassOf(typeof(DbContext)), () => "Non context supplied");
            ContextType = contextType;
        }

        public ApiModel Construct() {
            EntityParser parser = new EntityParser();
            return new ApiModel(FindResourceCollections().Select(parser.Dissect).ToArray());
        }

        private IEnumerable<SetProperties> FindResourceCollections() {
            return ContextType
                    .GetProperties()
                    .Where(inf => !inf.GetCustomAttributes<ApiExclusionAttribute>().Any() && inf.PropertyType.IsConstructedGenericType)
                    .Select(inf => new SetProperties {
                                        EntityType = inf.PropertyType.GetGenericArguments().First(),
                                        Attributes = inf.GetCustomAttributes(),
                                        Name = inf.Name
                    });
        }

    }
}
