using System;
using System.Collections.Generic;
using Rabbit.Duplication.Models;

namespace Rabbit.Duplication.Caches
{
    internal class EntityTypeAdapterCache
    {
        private static readonly object LockObject = new object();
        private static readonly Lazy<EntityTypeAdapterCache> LazyInitializer = new Lazy<EntityTypeAdapterCache>(() => new EntityTypeAdapterCache());

        private readonly IDictionary<Type, EntityTypeAdapter> _entityTypeAdapters = new Dictionary<Type, EntityTypeAdapter>();

        static EntityTypeAdapterCache()
        {
        }

        public static EntityTypeAdapterCache Current
        {
            get { return LazyInitializer.Value; }
        }

        public EntityTypeAdapter GetEntityTypeAdapter(Type entityType)
        {
            lock (LockObject)
            {
                if (_entityTypeAdapters.ContainsKey(entityType) == false)
                {
                    var typeAdapter = new EntityTypeAdapter(entityType);
                    typeAdapter.Initialize();

                    _entityTypeAdapters.Add(entityType, typeAdapter);
                }

                return _entityTypeAdapters[entityType];
            }
        }
    }
}
