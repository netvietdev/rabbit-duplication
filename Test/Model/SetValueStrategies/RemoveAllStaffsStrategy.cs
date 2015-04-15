using System.Reflection;
using Rabbit.Duplication.SetValueStrategies;

namespace Test.Model.SetValueStrategies
{
    public class RemoveAllStaffsStrategy : CustomSetValueStrategy<Manager>
    {
        protected override void SetValue(PropertyInfo property, Manager source, Manager target)
        {
            target.RemoveAllStaffs();
        }
    }
}
