namespace CostCraft.Contracts.Auth;

public record RegisterRequest(
    string userName,
    string Password,
    string PreferredCurrency);
