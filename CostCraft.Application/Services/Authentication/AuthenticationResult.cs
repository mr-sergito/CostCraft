using CostCraft.Domain.Entities;

namespace CostCraft.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);
