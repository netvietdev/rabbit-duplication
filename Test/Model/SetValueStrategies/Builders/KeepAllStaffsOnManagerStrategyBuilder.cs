using Duplication.SetValueStrategies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Test.Model.SetValueStrategies.Builders
{
    public class KeepAllStaffsOnManagerStrategyBuilder : PersonSetValueStrategyBuilder<Manager>
    {
        public override IDictionary<Expression<Func<Manager, object>>, ISetValueStrategy> Build()
        {
            var strategies = base.Build();

            strategies.Add(m => m.Staffs, new KeepSameValueStrategy());

            return strategies;
        }
    }
}
