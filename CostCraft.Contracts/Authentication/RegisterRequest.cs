namespace CostCraft.Contracts.Authentication;

public record RegisterRequest(
    string userName,
    string Password,
    string PreferredCurrency);
