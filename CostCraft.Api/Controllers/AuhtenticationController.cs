using CostCraft.Application.Authentication.Commands.Register;
using CostCraft.Application.Authentication.Common;
using CostCraft.Application.Authentication.Queries.Login;
using CostCraft.Contracts.Authentication;
using CostCraft.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CostCraft.Api.Controllers;

[Route("auth")]
public class AuhtenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuhtenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized, 
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}
