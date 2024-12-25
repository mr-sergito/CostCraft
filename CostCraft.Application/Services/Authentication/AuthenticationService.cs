using CostCraft.Application.Common.Interfaces.Authentication;

namespace CostCraft.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string username, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), username, "token");
    }

    public AuthenticationResult Register(string username, string password)
    {
        // Check if user already exists


        // Create user (generate unique ID)

        // Create JWT token
        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, username);

        return new AuthenticationResult(userId, username, token);
    }
}
