using Microsoft.AspNetCore.Mvc;

namespace CostCraft.Api.Controllers;

[Route("[controller]")]
public class ProductsController : ApiController
{
    [HttpGet]
    public IActionResult ListProducts()
    {
        return Ok(Array.Empty<string>());
    }
}
