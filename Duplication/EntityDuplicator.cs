using Duplication.Caches;
using Duplication.Extensions;
using Duplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Duplication
{
    internal class EntityDuplicator
    {
        public T Duplicate<T>(T source) where T : IEntityClonable<T>
        {
            var setValueStrategies = source.BuildSetValueStrategies();
            var registeredProperties = setValueStrategies.Keys.Select(x => x.GetPropertyInfo()).ToList();
            var entityAdapter = EntityTypeAdapterCache.Current.GetEntityTypeAdapter(typeof(T));

            ValidateRegisteredStrategies(entityAdapter.PublicProperties, registeredProperties);

            var duplicated = source.Clone();

            foreach (var kvp in setValueStrategies)
            {
                kvp.Value.SetValue(kvp.Key.GetPropertyInfo(), source, duplicated);
            }

            return duplicated;
        }

        private void ValidateRegisteredStrategies(IEnumerable<PropertyInfo> publicProperties, IEnumerable<PropertyInfo> registeredProperties)
        {
            var notRegisteredProperty =
                publicProperties.Where(p => p.CanWrite)
                    .FirstOrDefault(p => registeredProperties.All(rp => rp.Name != p.Name));

            if (notRegisteredProperty != null)
            {
                throw new ApplicationException("Not registered for property " + notRegisteredProperty.Name);
            }
        }
    }
}
