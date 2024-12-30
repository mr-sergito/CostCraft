using CostCraft.Application.Services.Authentication.Common;
using ErrorOr;

namespace CostCraft.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string username, string password);
}
