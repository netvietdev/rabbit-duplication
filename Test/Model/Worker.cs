using Duplication.Models;
using Duplication.SetValueStrategies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Test.Model
{
    public class Worker : Person, IEntityClonable<Worker>
    {
        private readonly IList<Car> _cars = new List<Car>();

        public static int Total
        {
            get;
            set;
        }

        public Worker()
        {
            Id = Guid.NewGuid();
        }

        public string WorkingFactory { get; set; }

        public IReadOnlyCollection<Car> Cars
        {
            get
            {
                return new ReadOnlyCollection<Car>(_cars);
            }
        }

        public void AddCar(Car car)
        {
            if (_cars.Contains(car) == false)
            {
                _cars.Add(car);
            }
        }

        public void RemoveCar(Car car)
        {
            if (_cars.Contains(car))
            {
                _cars.Remove(car);
            }
        }

        #region IEntityClonable members

        public Worker Clone()
        {
            return (Worker)MemberwiseClone();
        }

        public IDictionary<Expression<Func<Worker, object>>, ISetValueStrategy> BuildSetValueStrategies()
        {
            var registeredStrategies = BuildCommonSetValueStrategies<Worker>();

            registeredStrategies.Add(w => w.WorkingFactory, new KeepSameValueStrategy());

            return registeredStrategies;
        }

        #endregion

    }
}
