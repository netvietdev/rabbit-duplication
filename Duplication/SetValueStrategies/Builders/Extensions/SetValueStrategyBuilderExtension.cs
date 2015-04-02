using Duplication.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Duplication.SetValueStrategies.Builders.Extensions
{
    public static class SetValueStrategyBuilderExtension
    {
        public static IDictionary<Expression<Func<T, object>>, ISetValueStrategy> MergeWith<T>(
            this ISetValueStrategyBuilder<T> primaryBuilder,
            ISetValueStrategyBuilder<T> secondaryBuilder)
        {
            var results = primaryBuilder.Build();

            foreach (var strategyKvp in secondaryBuilder.Build())
            {
                if (results.All(kvp => kvp.Key.GetPropertyInfo().Name != strategyKvp.Key.GetPropertyInfo().Name))
                {
                    results.Add(strategyKvp);
                }
            }

            return results;
        }
    }
}
