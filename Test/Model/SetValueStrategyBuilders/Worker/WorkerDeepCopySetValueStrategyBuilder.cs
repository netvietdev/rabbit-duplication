using Duplication.SetValueStrategies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Test.Model.SetValueStrategies;

namespace Test.Model.SetValueStrategyBuilders.Worker
{
    public class WorkerDeepCopySetValueStrategyBuilder : DefaultWorkerSetValueStrategyBuilder
    {
        public override IDictionary<Expression<Func<Model.Worker, object>>, ISetValueStrategy> Build()
        {
            var strategies = base.Build();

            strategies.Add(w => w.Cars, new DuplicateCarsStrategy());

            return strategies;
        }
    }
}
