using System;
using Rabbit.Duplication.Models;
using Rabbit.Duplication.SetValueStrategies.Builders;
using Test.Model.SetValueStrategyBuilders.Worker;

namespace Test.Model
{
    public class Worker : Person, IEntityCloneable<Worker>
    {
        public static int Total
        {
            get;
            set;
        }

        public Worker()
        {
            Id = Guid.NewGuid();
        }

        public string WorkingFactory { get; set; }

        #region IEntityClonable members

        public Worker Clone()
        {
            return (Worker)MemberwiseClone();
        }
        
        #endregion

        public ISetValueStrategyBuilder<Worker> SetValueStrategyBuilder
        {
            get { return new DefaultWorkerSetValueStrategyBuilder(); }
        }
    }
}
