using Duplication.Models;
using Duplication.SetValueStrategies.Builders;
using System;
using Test.Model.SetValueStrategyBuilders.Car;

namespace Test.Model
{
    public class Car : IEntityCloneable<Car>
    {
        public Car()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Brand { get; set; }

        public Car Clone()
        {
            return (Car)MemberwiseClone();
        }

        public ISetValueStrategyBuilder<Car> SetValueStrategyBuilder
        {
            get { return new CarSetValueStrategyBuilder(); }
        }
    }
}
