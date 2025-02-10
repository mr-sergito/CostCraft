using CostCraft.Application.Auth.Common;
using CostCraft.Domain.UserAggregate.Enums;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Auth.Commands.Register;

public record RegisterCommand(
    string userName,
    string Password,
    Currency PreferredCurrency) : IRequest<ErrorOr<AuthResult>>;
