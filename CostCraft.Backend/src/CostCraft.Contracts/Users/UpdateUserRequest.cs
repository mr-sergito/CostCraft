namespace CostCraft.Contracts.Users;

public record UpdateUserRequest(
    string userName,
    string Password,
    string PreferredCurrency);
