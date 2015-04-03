using Duplication.SetValueStrategies;
using Duplication.SetValueStrategies.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Test.Model.SetValueStrategyBuilders
{
    public abstract class PersonSetValueStrategyBuilder<T> : ISetValueStrategyBuilder<T> where T : Person
    {
        public virtual IDictionary<Expression<Func<T, object>>, ISetValueStrategy> Build()
        {
            return new Dictionary<Expression<Func<T, object>>, ISetValueStrategy>()
            {
                {p => p.Id, new ResetValueStrategy(Guid.NewGuid())},
                {p => p.FullName, new KeepSameValueStrategy()},
            };
        }
    }
}
