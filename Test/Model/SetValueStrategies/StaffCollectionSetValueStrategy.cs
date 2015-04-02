using System.Reflection;
using Duplication.SetValueStrategies;

namespace Test.Model.SetValueStrategies
{
    public class StaffCollectionSetValueStrategy : CustomSetValueStrategy<Manager>
    {
        protected override void SetValue(PropertyInfo property, Manager source, Manager target)
        {
            target.RemoveAllStaffs();
        }
    }
}
