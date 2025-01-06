using CostCraft.Domain.ProductAggregate;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    int UnitsProduced,
    string UserId,
    decimal ProfitMarginPercentage,
    List<MaterialCommand> Materials,
    List<LaborCommand> Labors) : IRequest<ErrorOr<Product>>;

public record MaterialCommand(
    string Name,
    decimal PurchasedAmount,
    string PurchasedUnit,
    decimal PurchasedPrice,
    decimal UsedAmount,
    string UsedUnit);

public record LaborCommand(
    string TimeUnit,
    decimal TimePayRate,
    decimal TimeWorked);
