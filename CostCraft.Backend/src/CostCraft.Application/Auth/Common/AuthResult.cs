using CostCraft.Domain.UserAggregate;

namespace CostCraft.Application.Auth.Common;

public record AuthResult(
    User User,
    string Token);
