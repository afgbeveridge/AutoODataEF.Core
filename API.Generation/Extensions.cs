using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace API.Generation {

    internal static class AttributeExtensions {

        internal static TType FromAttribute<TType, TAttr>(this IEnumerable<Attribute> attrs, Func<TAttr, TType> f) where TAttr : Attribute {
            var attr = attrs.FirstOrDefault(a => a is TAttr);
            return attr == null ? default(TType) : f(attr as TAttr);
        }

    }

    internal static class TypeExtensions {

        internal static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TAttr>(this Type t) where TAttr : Attribute {
            return t.GetProperties().Where(inf => inf.GetCustomAttribute<TAttr>() != null);
        }

    }

}
