using CostCraft.Domain.UserAggregate;

namespace CostCraft.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
