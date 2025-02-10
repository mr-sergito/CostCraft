using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Domain.ProductAggregate;
using CostCraft.Domain.ProductAggregate.ValueObjects;

namespace CostCraft.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CostCraftDbCcontext _dbCcontext;

    public ProductRepository(CostCraftDbCcontext dbCcontext)
    {
        _dbCcontext = dbCcontext;
    }

    public void Add(Product product)
    {
        _dbCcontext.Add(product);
        _dbCcontext.SaveChanges();
    }

    public Product? GetProductById(ProductId id)
    {
        return _dbCcontext.Products.SingleOrDefault(p => p.Id == id);
    }
}
