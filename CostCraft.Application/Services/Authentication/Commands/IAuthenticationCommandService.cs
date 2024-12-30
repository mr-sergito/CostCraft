using CostCraft.Application.Services.Authentication.Common;
using ErrorOr;

namespace CostCraft.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string username, string password);
}
