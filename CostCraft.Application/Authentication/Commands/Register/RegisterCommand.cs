using CostCraft.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Username,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
