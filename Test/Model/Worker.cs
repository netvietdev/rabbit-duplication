using Duplication.Models;
using Duplication.SetValueStrategies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Test.Model
{
    public class Worker : Person, IEntityClonable<Worker>
    {
        public static int Total
        {
            get;
            set;
        }

        public string WorkingFactory { get; set; }

        public Worker Clone()
        {
            return (Worker)MemberwiseClone();
        }

        public IDictionary<Expression<Func<Worker, object>>, ISetValueStrategy> BuildSetValueStrategies()
        {
            var registeredStrategies = BuildCommonSetValueStrategies<Worker>();

            registeredStrategies.Add(w => w.WorkingFactory, new KeepSameValueStrategy());

            return registeredStrategies;
        }
    }
}
