using CostCraft.Application.Auth.Common;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Auth.Queries.Login;

public record LoginQuery(
    string UserName,
    string Password) : IRequest<ErrorOr<AuthResult>>;
