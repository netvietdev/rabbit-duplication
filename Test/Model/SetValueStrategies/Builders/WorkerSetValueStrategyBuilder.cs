using Duplication.SetValueStrategies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Test.Model.SetValueStrategies.Builders
{
    public class WorkerSetValueStrategyBuilder : PersonSetValueStrategyBuilder<Worker>
    {
        public override IDictionary<Expression<Func<Worker, object>>, ISetValueStrategy> Build()
        {
            var strategies = base.Build();

            strategies.Add(w => w.WorkingFactory, new KeepSameValueStrategy());

            return strategies;
        }
    }
}
