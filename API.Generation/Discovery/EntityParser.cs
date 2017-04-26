using API.Generation.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace API.Generation.Discovery {

    internal class EntityParser {

        internal ControllerModel Dissect(SetProperties props) {
            var key = FindKeyType(props.EntityType);
            return new ControllerModel {
                ResourceCollectionName = props.Attributes.FromAttribute<string, ApiResourceCollectionAttribute>(a => a.Name) ?? props.Name,
                ResourceIdType = key.type,
                KeyName = key.name,
                ExposedProperties = FindExposedProperties(props.EntityType),
                Properties = props,
                Directives = FindPropertyDirectives(props.EntityType)
            };
        }

        private (Type type, string name) FindKeyType(Type t) {
            PropertyInfo info = FindKeyIn(t);
            Assert.True<ArgumentException>(info != null, () => $"No key defined for {t.Name}");
            return (type: info.PropertyType, name: info.Name);
        }

        private PropertyInfo FindKeyIn(Type t) {
            var conventionKeyName = $"{t.Name}Id";
            var candidates = t.GetProperties().Where(info => info.Name == conventionKeyName || info.GetCustomAttribute<KeyAttribute>() != null);
            Assert.True<ArgumentException>(candidates.Count() == 1, () => "Type has more than one or no key " + t.Name);
            return candidates.First();
        }

        private IEnumerable<ResourceProperty> FindExposedProperties(Type t) {
            return t.GetPropertiesWithAttribute<ApiExposedResourcePropertyAttribute>()
                    .Select(inf => new ResourceProperty {
                                        Name = inf.Name,
                                        Type = inf.PropertyType,
                                        IsNavigationProperty = inf.PropertyType.IsGenericType && inf.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)
                    });
        }

        private IEnumerable<PropertyDirectives> FindPropertyDirectives(Type t) {
            return t.GetPropertiesWithAttribute<ApiNullifyOnCreateAttribute>()
                    .Select(inf => new PropertyDirectives { Name = inf.Name, NullifyOnCreate = true, Type = inf.PropertyType });
        }

    }

}
