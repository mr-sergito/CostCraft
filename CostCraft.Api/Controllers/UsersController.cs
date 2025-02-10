using CostCraft.Contracts.Users;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CostCraft.Api.Controllers;

[Route("users")]
public class UsersController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public UsersController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync(UpdateUserRequest request, string userId)
    {
        throw new NotImplementedException();

    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
