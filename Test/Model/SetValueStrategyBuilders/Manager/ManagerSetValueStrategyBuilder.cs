using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rabbit.Duplication.SetValueStrategies;
using Test.Model.SetValueStrategies;

namespace Test.Model.SetValueStrategyBuilders.Manager
{
    public class ManagerSetValueStrategyBuilder : PersonSetValueStrategyBuilder<Model.Manager>
    {
        public override IDictionary<Expression<Func<Model.Manager, object>>, ISetValueStrategy> Build()
        {
            var strategies = base.Build();

            strategies.Add(m => m.Staffs, new RemoveAllStaffsStrategy());

            return strategies;
        }
    }
}
