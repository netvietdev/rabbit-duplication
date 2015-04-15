using System;
using Rabbit.Duplication.Models;
using Rabbit.Duplication.SetValueStrategies.Builders;
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
