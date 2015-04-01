using System.Reflection;

namespace Duplication.SetValueStrategies
{
    public class KeepSameValueStrategy : ISetValueStrategy
    {
        public void SetValue(PropertyInfo property, object source, object target)
        {
            // Do nothing
        }
    }
}
