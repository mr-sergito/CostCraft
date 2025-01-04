using CostCraft.Domain.Common.Models;
using CostCraft.Domain.Product.Enums;
using CostCraft.Domain.Product.ValueObjects;

namespace CostCraft.Domain.Product.Entities;

public sealed class Labor : Entity<LaborId>
{
    public MeasurementUnit TimeUnit { get; }
    public decimal TimePayRate { get; }
    public decimal TimeWorked { get; }
    public decimal TimeCost { get; } // Not setteable, not sure if this belongs here

    private Labor(
        LaborId laborId, 
        MeasurementUnit timeUnit,
        decimal timePayRate, 
        decimal timeWorked) 
        : base(laborId)
    {
        TimeUnit = timeUnit;
        TimePayRate = timePayRate;
        TimeWorked = timeWorked;
    }

    public static Labor Create(
        MeasurementUnit timeUnit, 
        decimal timePayRate, 
        decimal timeWorked)
    {
        return new(
            LaborId.CreateUnique(),
            timeUnit, 
            timePayRate, 
            timeWorked);
    }
}
