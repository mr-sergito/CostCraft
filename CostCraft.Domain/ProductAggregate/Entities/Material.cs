using CostCraft.Domain.Common.Models;
using CostCraft.Domain.ProductAggregate.Enums;
using CostCraft.Domain.ProductAggregate.ValueObjects;

namespace CostCraft.Domain.ProductAggregate.Entities;

public sealed class Material : Entity<MaterialId>
{
    public string Name { get; }
    public decimal PurchasedAmount { get; }
    public MeasurementUnit PurchasedUnit { get; }
    public decimal PurchasedPrice { get; }
    public decimal UsedAmount { get; }
    public MeasurementUnit UsedUnit { get; }
    public decimal UsedCost { get; }

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
}
