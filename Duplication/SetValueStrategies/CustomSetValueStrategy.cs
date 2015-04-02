using System.Reflection;

namespace Duplication.SetValueStrategies
{
    public abstract class CustomSetValueStrategy<T> : ISetValueStrategy
    {
        public void SetValue(PropertyInfo property, object source, object target)
        {
            SetValue(property, (T)source, (T)target);
        }

        protected abstract void SetValue(PropertyInfo property, T source, T target);
    }
}
