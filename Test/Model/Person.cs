using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Test.Model
{
    public abstract class Person
    {
        private int _age;
        private IList<Car> _cars;

        protected Person()
        {
            InitializeCars();
        }

        public static int Count { get; set; }

        public Guid Id { get; set; }

        public string FullName { get; set; }

        public int Age
        {
            get { return _age; }
        }

        public void SetAge(int age)
        {
            _age = age;
        }

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

        public void InitializeCars()
        {
            _cars = new List<Car>();
        }
    }
}
