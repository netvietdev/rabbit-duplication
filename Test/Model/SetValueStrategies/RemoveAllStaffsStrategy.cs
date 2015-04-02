using System.Reflection;
using Duplication.SetValueStrategies;

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
