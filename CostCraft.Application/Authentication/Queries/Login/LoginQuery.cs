using CostCraft.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Username,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
