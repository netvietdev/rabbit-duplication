using Duplication.SetValueStrategies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Test.Model.SetValueStrategyBuilders.Worker
{
    public class DefaultWorkerSetValueStrategyBuilder : PersonSetValueStrategyBuilder<Model.Worker>
    {
        public override IDictionary<Expression<Func<Model.Worker, object>>, ISetValueStrategy> Build()
        {
            var strategies = base.Build();

            strategies.Add(w => w.WorkingFactory, new KeepSameValueStrategy());

            return strategies;
        }
    }
}
