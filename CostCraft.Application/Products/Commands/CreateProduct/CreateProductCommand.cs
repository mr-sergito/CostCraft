using CostCraft.Domain.ProductAggregate;
using CostCraft.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    int UnitsProduced,
    UserId UserId,
    decimal ProfitMarginPercentage,
    List<MaterialCommand> Materials,
    List<LaborCommand> Labors) : IRequest<ErrorOr<Product>>;

public record MaterialCommand(
    string Name,
    decimal PurchasedAmount,
    string PurchasedUnit,
    decimal PurchasedPrice,
    decimal UserAmount,
    string UsedUnit);

public record LaborCommand(
    string TimeUnit,
    decimal TimePayRate,
    decimal TimeWorked);
