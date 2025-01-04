using CostCraft.Domain.Common.Models;

namespace CostCraft.Domain.Product.ValueObjects;

public sealed class LaborId : ValueObject
{
    public Guid Value { get; }

    public LaborId(Guid value)
    {
        Value = value;
    }

    public static LaborId CreateUnique()
    {
        return new LaborId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
