using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rabbit.Duplication.SetValueStrategies.Builders
{
    public interface ISetValueStrategyBuilder<T>
    {
        IDictionary<Expression<Func<T, object>>, ISetValueStrategy> Build();
    }
}
