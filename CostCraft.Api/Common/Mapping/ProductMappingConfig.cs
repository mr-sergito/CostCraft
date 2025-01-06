using CostCraft.Application.Products.Commands.CreateProduct;
using CostCraft.Contracts.Products;
using CostCraft.Domain.ProductAggregate;
using CostCraft.Domain.ProductAggregate.Entities;
using Mapster;

namespace CostCraft.Api.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateProductRequest Request, string UserId), CreateProductCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Product, ProductResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value);

        config.NewConfig<Material, MaterialResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Labor, LaborResponse>()
           .Map(dest => dest.Id, src => src.Id.Value);
    }
}
