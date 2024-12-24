namespace CostCraft.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string username, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), username, "token");
    }

    public AuthenticationResult Register(string username, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), username, "token");
    }
}
