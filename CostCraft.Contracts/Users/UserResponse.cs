namespace CostCraft.Contracts.Users;

public record UserResponse(
    Guid Id,
    string userName,
    string PreferredCurrency,
    string Currency);
