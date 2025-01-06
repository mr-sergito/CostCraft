using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Domain.ProductAggregate;
using CostCraft.Domain.ProductAggregate.Entities;
using CostCraft.Domain.ProductAggregate.Enums;
using CostCraft.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var product = Product.Create(
            name: request.Name,
            unitsProduced: request.UnitsProduced,
            userId: UserId.CreateFromString(request.UserId),
            profitMarginPercentage: request.ProfitMarginPercentage,
            materials: request.Materials.ConvertAll(material => Material.Create(
                material.Name,
                material.PurchasedAmount,
                (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), material.PurchasedUnit),
                material.PurchasedPrice,
                material.UsedAmount,
                (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), material.UsedUnit))),
            labors: request.Labors.ConvertAll(labor => Labor.Create(
                (MeasurementUnit)Enum.Parse(typeof (MeasurementUnit), labor.TimeUnit),
                labor.TimePayRate,
                labor.TimeWorked)));

        _productRepository.Add(product);

        return product!;
    }
}
