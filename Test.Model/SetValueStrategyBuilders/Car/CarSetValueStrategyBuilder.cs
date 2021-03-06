﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rabbit.Duplication.SetValueStrategies;
using Rabbit.Duplication.SetValueStrategies.Builders;

namespace Test.Model.SetValueStrategyBuilders.Car
{
    public class CarSetValueStrategyBuilder : ISetValueStrategyBuilder<Model.Car>
    {
        public IDictionary<Expression<Func<Model.Car, object>>, ISetValueStrategy> Build()
        {
            return new Dictionary<Expression<Func<Model.Car, object>>, ISetValueStrategy>()
            {
                {c => c.Id, new ResetValueStrategy(Guid.NewGuid())},
                {c => c.Brand, new KeepSameValueStrategy()}
            };
        }
    }
}
