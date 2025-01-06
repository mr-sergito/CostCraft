using CostCraft.Domain.Common.Models;

namespace CostCraft.Domain.ProductAggregate.ValueObjects;

public sealed class LaborId : ValueObject
{
    public Guid Value { get; private set; }

    public LaborId(Guid value)
    {
        Value = value;
    }

    public static LaborId CreateUnique()
    {
        return new LaborId(Guid.NewGuid());
    }

    public static LaborId CreateFromString(string value)
    {
        if (Guid.TryParse(value, out var guidValue))
        {
            return new LaborId(guidValue);
        }

        throw new ArgumentException("Invalid GUID format.", nameof(value)); // Should it be a problem?
    }

    public static LaborId CreateFromGuid(Guid value)
    {
        // TODO: enforce invariants
        return new LaborId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
