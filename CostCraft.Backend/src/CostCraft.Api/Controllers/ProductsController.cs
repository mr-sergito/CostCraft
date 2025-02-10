using CostCraft.Application.Products.Commands.CreateProduct;
using CostCraft.Contracts.Products;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CostCraft.Api.Controllers;

[Route("users/{userId}/products")]
public class ProductsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public ProductsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductRequest request, string userId)
    {
        var command = _mapper.Map<CreateProductCommand>((request, userId));

        var createProductResult = await _mediator.Send(command);

        return createProductResult.Match(
            product => Ok(_mapper.Map<ProductResponse>(product)),
            errors => Problem(errors));
    }
}
