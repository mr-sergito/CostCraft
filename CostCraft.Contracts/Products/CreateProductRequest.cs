namespace CostCraft.Contracts.Products;

public record CreateProductRequest(
    string Name,
    int UnitsProduced,
    decimal ProfitMarginPercentage,
    List<MaterialRequest> Materials, 
    List<LaborRequest> Labors);

public record MaterialRequest(
    string Name,
    decimal PurchasedAmount,
    string PurchasedUnit,
    decimal PurchasedPrice,
    decimal UsedAmount,
    string UsedUnit);

public record LaborRequest(
    string TimeUnit,
    decimal TimePayRate,
    decimal TimeWorked);