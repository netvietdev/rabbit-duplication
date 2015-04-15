using Rabbit.Duplication.SetValueStrategies.Builders;

namespace Rabbit.Duplication.Models
{
    public interface IEntityCloneable<T>
    {
        T Clone();

        ISetValueStrategyBuilder<T> SetValueStrategyBuilder { get; }
    }
}
