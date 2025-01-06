using CostCraft.Domain.Common.Models;
using CostCraft.Domain.ProductAggregate.Entities;
using CostCraft.Domain.ProductAggregate.ValueObjects;
using CostCraft.Domain.UserAggregate.ValueObjects;

namespace CostCraft.Domain.ProductAggregate;

public class Product : AggregateRoot<ProductId>
{
    private readonly List<Material> _materials = [];
    private readonly List<Labor> _labors = [];

    public string Name { get; private set; }
    public int UnitsProduced { get; private set; }
    public UserId UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public decimal ProfitMarginPercentage { get; private set; }

    public IReadOnlyList<Material> Materials => _materials.AsReadOnly();
    public IReadOnlyList<Labor> Labors => _labors.AsReadOnly();

    public decimal TotalCost { get; private set; }
    public decimal SalePrice { get; private set; }

    private Product(
        ProductId productId,
        string name,
        int unitsProduced,
        UserId userId,
        DateTime createdAt,
        DateTime updatedAt,
        decimal profitMarginPercentage,
        List<Material> materials,
        List<Labor> labors)
        : base(productId)
    {
        Name = name;
        UnitsProduced = unitsProduced;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        ProfitMarginPercentage = profitMarginPercentage;

        _materials.AddRange(materials);
        _labors.AddRange(labors);

        TotalCost = Math.Round(materials.Sum(x => x.UsedCost) + labors.Sum(x => x.TimeCost), 2);
        SalePrice = Math.Round(TotalCost * (1 + ProfitMarginPercentage / 100m), 2);
    }

    public static Product Create(
        string name,
        int unitsProduced,
        UserId userId,
        decimal profitMarginPercentage,
        List<Material> materials,
        List<Labor> labors)
    {
        return new Product(
            ProductId.CreateUnique(),
            name,
            unitsProduced,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow,
            profitMarginPercentage,
            materials,
            labors);
    }

#pragma warning disable CS8618
    private Product()
    {

    }
#pragma warning restore CS8618
}
