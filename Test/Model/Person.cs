using Duplication.SetValueStrategies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Test.Model
{
    public abstract class Person
    {
        private int _age;

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

        protected IDictionary<Expression<Func<T, object>>, ISetValueStrategy> BuildCommonSetValueStrategies<T>() where T : Person
        {
            return new Dictionary<Expression<Func<T, object>>, ISetValueStrategy>()
            {
                {p => p.Id, new ResetValueStrategy(Guid.NewGuid())},
                {p => p.FullName, new KeepSameValueStrategy()},
            };
        }
    }
}
