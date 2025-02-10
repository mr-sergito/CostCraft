using CostCraft.Domain.UserAggregate;
using CostCraft.Domain.UserAggregate.Enums;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Users.Commands.UpdateUser;

public record UpdateUserCommand(
    string UserId,
    string UserName,
    string Password,
    Currency PreferredCurrency) : IRequest<ErrorOr<User>>;
