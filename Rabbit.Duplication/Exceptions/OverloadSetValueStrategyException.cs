using System;

namespace Rabbit.Duplication.Exceptions
{
    public class OverloadSetValueStrategyException : Exception
    {
        private readonly Type _entityType;

        public OverloadSetValueStrategyException(Type entityType)
        {
            _entityType = entityType;
        }

        public override string Message
        {
            get
            {
                return string.Format("The overloadSetValueStrategy must be different than the registered one on type {0}", _entityType.FullName);
            }
        }
    }
}
