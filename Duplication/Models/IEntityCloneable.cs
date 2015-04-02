using Duplication.SetValueStrategies.Builders;

namespace Duplication.Models
{
    public interface IEntityCloneable<T>
    {
        T Clone();

        ISetValueStrategyBuilder<T> SetValueStrategyBuilder { get; }
    }
}
