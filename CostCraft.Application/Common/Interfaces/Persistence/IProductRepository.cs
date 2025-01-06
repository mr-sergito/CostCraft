using CostCraft.Domain.ProductAggregate;
using CostCraft.Domain.ProductAggregate.ValueObjects;

namespace CostCraft.Application.Common.Interfaces.Persistence;

public interface IProductRepository
{
    void Add(Product product);
    Product? GetProductById(ProductId id);
}
