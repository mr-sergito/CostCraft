﻿using CostCraft.Domain.Common.Models;

namespace CostCraft.Domain.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; private set; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    public static UserId CreateFromString(string value)
    {
        if (Guid.TryParse(value, out var guidValue))
        {
            return new UserId(guidValue);
        }

        throw new ArgumentException("Invalid GUID format.", nameof(value)); // Should it be a problem?
    }

    public static UserId CreateFromGuid(Guid value)
    {
        // TODO: enforce invariants
        return new UserId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
