namespace CostCraft.Contracts.Products;

public record ProductResponse(
    string Id,
    string Name,
    int UnitsProduced,
    string UserId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    decimal ProfitMarginPercentage,
    List<MaterialResponse> Materials,
    List<LaborResponse> Labors,
    decimal TotalCost,
    decimal SalePrice);

public record MaterialResponse(
    string Id,
    string Name,
    decimal PurchasedAmount,
    string PurchasedUnit,
    decimal PurchasedPrice,
    decimal UsedAmount,
    string UsedUnit);

public record LaborResponse(
    string Id,
    string TimeUnit,
    decimal TimePayRate,
    decimal TimeWorked);