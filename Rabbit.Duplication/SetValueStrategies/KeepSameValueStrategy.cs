using System.Reflection;

namespace Rabbit.Duplication.SetValueStrategies
{
    public class KeepSameValueStrategy : ISetValueStrategy
    {
        public void SetValue(PropertyInfo property, object source, object target)
        {
            // Do nothing
        }
    }
}
