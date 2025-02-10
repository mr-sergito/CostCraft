using CostCraft.Domain.Common.Models;

namespace CostCraft.Domain.ProductAggregate.ValueObjects;

public sealed class MaterialId : ValueObject
{
    public Guid Value { get; private set; }

    public MaterialId(Guid value)
    {
        Value = value;
    }

    public static MaterialId CreateUnique()
    {
        return new MaterialId(Guid.NewGuid());
    }

    public static MaterialId CreateFromString(string value)
    {
        if (Guid.TryParse(value, out var guidValue))
        {
            return new MaterialId(guidValue);
        }

        throw new ArgumentException("Invalid GUID format.", nameof(value)); // Should it be a problem?
    }

    public static MaterialId CreateFromGuid(Guid value)
    {
        // TODO: enforce invariants
        return new MaterialId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
