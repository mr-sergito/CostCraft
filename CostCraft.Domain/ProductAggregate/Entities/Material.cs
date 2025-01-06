using CostCraft.Domain.Common.Models;
using CostCraft.Domain.ProductAggregate.Enums;
using CostCraft.Domain.ProductAggregate.ValueObjects;

namespace CostCraft.Domain.ProductAggregate.Entities;

public sealed class Material : Entity<MaterialId>
{
    public string Name { get; private set; }
    public decimal PurchasedAmount { get; private set; }
    public MeasurementUnit PurchasedUnit { get; private set; }
    public decimal PurchasedPrice { get; private set; }
    public decimal UsedAmount { get; private set; }
    public MeasurementUnit UsedUnit { get; private set; }
    public decimal UsedCost { get; private set; }

    private Material(
        MaterialId materialId,
        string name,
        decimal purchasedAmount,
        MeasurementUnit purchasedUnit,
        decimal purchasedPrice,
        decimal usedAmount,
        MeasurementUnit usedUnit)
        : base(materialId)
    {
        Name = name;
        PurchasedAmount = purchasedAmount;
        PurchasedUnit = purchasedUnit;
        PurchasedPrice = purchasedPrice;
        UsedAmount = usedAmount;
        UsedUnit = usedUnit;

        UsedCost = usedAmount * purchasedPrice;
    }

    public static Material Create(
        string name,
        decimal purchasedAmount,
        MeasurementUnit purchasedUnit,
        decimal purchasedPrice,
        decimal usedAmount,
        MeasurementUnit usedUnit)
    {
        return new Material(
            MaterialId.CreateUnique(),
            name,
            purchasedAmount,
            purchasedUnit,
            purchasedPrice,
            usedAmount,
            usedUnit);
    }

#pragma warning disable CS8618
    private Material()
    {

    }
#pragma warning restore CS8618
}
