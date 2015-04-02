using Duplication.Models;

namespace Duplication.Extensions
{
    public static class EntityDuplicationExtension
    {
        public static T Duplicate<T>(this T source) where T : IEntityCloneable<T>
        {
            return OnDuplicate(source);
        }

        private static T OnDuplicate<T>(T source) where T : IEntityCloneable<T>
        {
            return new EntityDuplicator().Duplicate(source);
        }
    }
}
