using System.Reflection;

namespace Rabbit.Duplication.SetValueStrategies
{
    public interface ISetValueStrategy
    {
        void SetValue(PropertyInfo property, object source, object target);
    }
}
