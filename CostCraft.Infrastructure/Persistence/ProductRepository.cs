using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Domain.ProductAggregate;
using CostCraft.Domain.ProductAggregate.ValueObjects;

namespace CostCraft.Infrastructure.Persistence;

public class ProductRepository : IProductRepository
{
    private static readonly List<Product> _products = [];

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public Product? GetProductById(ProductId id)
    {
        return _products.SingleOrDefault(p => p.Id == id);
    }
}
