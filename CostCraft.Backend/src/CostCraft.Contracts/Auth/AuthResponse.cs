namespace CostCraft.Contracts.Auth;

public record AuthResponse(
    Guid Id,
    string UserName,
    string PreferredCurrency,
    string Token);
