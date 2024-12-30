using CostCraft.Application.Authentication.Commands.Register;
using CostCraft.Application.Authentication.Common;
using CostCraft.Application.Authentication.Queries.Login;
using CostCraft.Contracts.Authentication;
using CostCraft.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CostCraft.Api.Controllers;

[Route("auth")]
public class AuhtenticationController : ApiController
{
    private readonly ISender _sender;

    public AuhtenticationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Username, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _sender.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var query = new LoginQuery(request.Username, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _sender.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized, 
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Username,
            authResult.Token);
    }
}
