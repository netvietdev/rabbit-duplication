using System;
using System.Reflection;

namespace Rabbit.Duplication.Exceptions
{
    public class NotRegisteredSetValueStrategyException : Exception
    {
        private readonly PropertyInfo _property;

        public NotRegisteredSetValueStrategyException(PropertyInfo property)
        {
            _property = property;
        }

        public override string Message
        {
            get
            {
                return string.Format("Missing strategy for property {0}", _property.Name);
            }
        }
    }
}
