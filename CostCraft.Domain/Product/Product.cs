using CostCraft.Domain.Common.Models;
using CostCraft.Domain.Product.Entities;
using CostCraft.Domain.Product.ValueObjects;
using CostCraft.Domain.User.ValueObjects;

namespace CostCraft.Domain.Product;

public class Product : AggregateRoot<ProductId>
{
    private readonly List<Material> _materials = [];
    private readonly List<Labor> _labors = [];

    public string Name { get; }
    public int UnitsProduced { get; }
    public UserId UserId { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    public decimal ProfitMarginPercentage { get; }

    public IReadOnlyList<Material> Materials => _materials.AsReadOnly();
    public IReadOnlyList<Labor> Labors => _labors.AsReadOnly();

    public decimal TotalCost // Not setteable, not sure if this belongs here
    {
        get
        {
            return Materials.Sum(x => x.UsedCost) + Labors.Sum(x => x.TimeCost);
        }
    }
    public decimal SalePrice // Not setteable, not sure if this belongs here
    {
        get
        {
            decimal profitFactor = 1 + (ProfitMarginPercentage / 100m);
            return TotalCost * profitFactor;
        }
    }

    private Product(
        ProductId productId,
        string name,
        int unitsProduced,
        UserId userId,
        DateTime createdAt,
        DateTime updatedAt,
        decimal profitMarginPercentage) 
        : base(productId)
    {
        Name = name;
        UnitsProduced = unitsProduced;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        ProfitMarginPercentage = profitMarginPercentage;
    }

    public static Product Create(
        string name,
        int unitsProduced,
        UserId userId,
        decimal profitMarginPercentage)
    {
        return new Product(
            ProductId.CreateUnique(),
            name,
            unitsProduced,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow,
            profitMarginPercentage);
    }
}
