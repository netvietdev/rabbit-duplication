using Duplication.Exceptions;
using Duplication.Models;
using Duplication.SetValueStrategies.Builders;

namespace Duplication.Extensions
{
    public static class EntityDuplicationExtension
    {
        public static T Duplicate<T>(this T source) where T : IEntityCloneable<T>
        {
            return OnDuplicate(source);
        }

        public static T Duplicate<T>(this T source, ISetValueStrategyBuilder<T> overloadSetValueStrategyBuilder) where T : IEntityCloneable<T>
        {
            if (overloadSetValueStrategyBuilder == null)
            {
                return OnDuplicate(source);
            }

            if (overloadSetValueStrategyBuilder.GetType() == source.SetValueStrategyBuilder.GetType())
            {
                throw new OverloadSetValueStrategyException(source.GetType());
            }

            return OnDuplicate(source, overloadSetValueStrategyBuilder);
        }

        private static T OnDuplicate<T>(T source) where T : IEntityCloneable<T>
        {
            return new EntityDuplicator().Duplicate(source);
        }

        private static T OnDuplicate<T>(T source, ISetValueStrategyBuilder<T> overloadSetValueStrategyBuilder) where T : IEntityCloneable<T>
        {
            return new EntityDuplicator().Duplicate(source, overloadSetValueStrategyBuilder);
        }
    }
}
