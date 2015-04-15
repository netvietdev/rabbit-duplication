using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Rabbit.Duplication.Models
{
    internal class EntityTypeAdapter
    {
        private readonly Type _entityType;

        public IReadOnlyCollection<PropertyInfo> PublicProperties
        {
            get;
            private set;
        }

        public EntityTypeAdapter(Type entityType)
        {
            _entityType = entityType;
        }

        public void Initialize()
        {
            var publicProperties = _entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PublicProperties = new ReadOnlyCollection<PropertyInfo>(publicProperties);
        }
    }
}
