using CostCraft.Domain.Common.Models;

namespace CostCraft.Domain.ProductAggregate.ValueObjects;

public sealed class ProductId : ValueObject
{
    public Guid Value { get; private set; }

    public ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId CreateUnique()
    {
        return new ProductId(Guid.NewGuid());
    }

    public static ProductId CreateFromString(string value)
    {
        if (Guid.TryParse(value, out var guidValue))
        {
            return new ProductId(guidValue);
        }

        throw new ArgumentException("Invalid GUID format.", nameof(value)); // Should it be a problem?
    }

    public static ProductId CreateFromGuid(Guid value)
    {
        // TODO: enforce invariants
        return new ProductId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
