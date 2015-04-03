using Duplication.Models;
using Duplication.SetValueStrategies.Builders;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Test.Model.SetValueStrategyBuilders.Manager;

namespace Test.Model
{
    public class Manager : Person, IEntityCloneable<Manager>
    {
        private readonly IList<Person> _staffs = new List<Person>();

        public IReadOnlyCollection<Person> Staffs
        {
            get { return new ReadOnlyCollection<Person>(_staffs); }
        }

        public void AddStaff(Person staff)
        {
            if (_staffs.Contains(staff) == false)
            {
                _staffs.Add(staff);
            }
        }

        public void RemoveStaff(Person staff)
        {
            if (_staffs.Contains(staff))
            {
                _staffs.Remove(staff);
            }
        }

        public void RemoveAllStaffs()
        {
            _staffs.Clear();
        }

        public Manager Clone()
        {
            return (Manager)MemberwiseClone();
        }

        public ISetValueStrategyBuilder<Manager> SetValueStrategyBuilder
        {
            get { return new ManagerSetValueStrategyBuilder(); }
        }
    }
}
