using System.Reflection;

namespace Duplication.SetValueStrategies
{
    public interface ISetValueStrategy
    {
        void SetValue(PropertyInfo property, object source, object target);
    }
}
