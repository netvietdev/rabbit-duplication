using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Duplication.SetValueStrategies;

namespace Duplication.Models
{
    public interface IEntityClonable<T>
    {
        T Clone();

        IDictionary<Expression<Func<T, object>>, ISetValueStrategy> BuildSetValueStrategies();
    }
}
