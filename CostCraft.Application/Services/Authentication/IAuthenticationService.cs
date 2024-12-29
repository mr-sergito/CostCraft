using ErrorOr;

namespace CostCraft.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(string username, string password);
    ErrorOr<AuthenticationResult> Login(string username, string password);
}
