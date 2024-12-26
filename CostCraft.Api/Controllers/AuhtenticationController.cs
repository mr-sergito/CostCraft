using CostCraft.Application.Services.Authentication;
using CostCraft.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CostCraft.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuhtenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuhtenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.Username, request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Username,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Username, request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Username,
            authResult.Token);

        return Ok(response);
    }
}
