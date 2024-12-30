using CostCraft.Domain.Entities;

namespace CostCraft.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
