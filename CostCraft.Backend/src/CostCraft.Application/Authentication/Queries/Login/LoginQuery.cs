using CostCraft.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Authentication.Queries.Login;

public record LoginQuery(
    string UserName,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
