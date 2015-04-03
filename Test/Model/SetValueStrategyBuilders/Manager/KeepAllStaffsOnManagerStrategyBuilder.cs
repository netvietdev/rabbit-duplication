using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Duplication.SetValueStrategies;

namespace Test.Model.SetValueStrategyBuilders.Manager
{
    public class KeepAllStaffsOnManagerStrategyBuilder : PersonSetValueStrategyBuilder<Model.Manager>
    {
        public override IDictionary<Expression<Func<Model.Manager, object>>, ISetValueStrategy> Build()
        {
            var strategies = base.Build();

            strategies.Add(m => m.Staffs, new KeepSameValueStrategy());

            return strategies;
        }
    }
}
