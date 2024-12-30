using CostCraft.Domain.Entities;

namespace CostCraft.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
