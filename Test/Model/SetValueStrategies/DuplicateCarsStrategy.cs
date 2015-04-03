using Duplication;
using Duplication.SetValueStrategies;
using System.Reflection;

namespace Test.Model.SetValueStrategies
{
    public class DuplicateCarsStrategy : CustomSetValueStrategy<Person>
    {
        protected override void SetValue(PropertyInfo property, Person source, Person target)
        {
            target.InitializeCars();

            foreach (var sourceCar in source.Cars)
            {
                target.AddCar(sourceCar.Duplicate());
            }
        }
    }
}
