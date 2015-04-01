using System.Reflection;

namespace Duplication.SetValueStrategies
{
    public class ResetValueStrategy : ISetValueStrategy
    {
        private readonly object _defaultValue;

        /// <summary>
        /// If type of property is a value type, do not need to set default value if it is not different than default(T)
        /// </summary>
        public ResetValueStrategy()
            : this(null)
        {
        }

        public ResetValueStrategy(object defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public void SetValue(PropertyInfo property, object source, object target)
        {
            property.SetValue(target, _defaultValue);
        }
    }
}
