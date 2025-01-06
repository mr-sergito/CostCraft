using CostCraft.Domain.Common.Models;

namespace CostCraft.Domain.ProductAggregate.ValueObjects;

public sealed class MaterialId : ValueObject
{
    public Guid Value { get; }

    public MaterialId(Guid value)
    {
        Value = value;
    }

    public static MaterialId CreateUnique()
    {
        return new MaterialId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
