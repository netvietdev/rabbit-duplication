using System;

namespace Test.Model
{
    public class Car
    {
        public Car()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Brand { get; set; }
    }
}
