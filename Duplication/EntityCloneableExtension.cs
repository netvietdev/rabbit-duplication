using Duplication.Exceptions;
using Duplication.Models;
using Duplication.SetValueStrategies.Builders;
using System;

namespace Duplication
{
    public static class EntityCloneableExtension
    {
        /// <summary>
        /// Duplicate an entity with default strategies configured in its type.
        /// </summary>
        public static T Duplicate<T>(this T source) where T : IEntityCloneable<T>
        {
            return new EntityDuplicator().Duplicate(source);
        }

        /// <summary>
        /// Duplicate an entity with overloadable set value strategies.
        /// The default strategies of source's type will be replaced by the one in overloadable builder.
        /// </summary>
        public static T Duplicate<T>(this T source, ISetValueStrategyBuilder<T> overloadSetValueStrategyBuilder)
            where T : IEntityCloneable<T>
        {
            return new EntityDuplicator().Duplicate(source, overloadSetValueStrategyBuilder);
        }

        /// <summary>
        /// Duplicate an entity with custom action on duplicated object.
        /// </summary>
        public static T Duplicate<T>(this T source, Action<T> afterDuplicateAction)
            where T : IEntityCloneable<T>
        {
            var duplicated = new EntityDuplicator().Duplicate(source);

            afterDuplicateAction(duplicated);

            return duplicated;
        }

        /// <summary>
        /// Duplicate an entity with overloadable set value strategies and custom action on duplicated object.
        /// The default strategies of source's type will be replaced by the one in overloadable builder.
        /// </summary>
        public static T Duplicate<T>(this T source,
            ISetValueStrategyBuilder<T> overloadSetValueStrategyBuilder,
            Action<T> afterDuplicateAction)
            where T : IEntityCloneable<T>
        {
            if (overloadSetValueStrategyBuilder.GetType() == source.SetValueStrategyBuilder.GetType())
            {
                throw new OverloadSetValueStrategyException(source.GetType());
            }

            var duplicated = new EntityDuplicator().Duplicate(source, overloadSetValueStrategyBuilder);

            if (afterDuplicateAction != null)
            {
                afterDuplicateAction(duplicated);
            }

            return duplicated;
        }
    }
}
