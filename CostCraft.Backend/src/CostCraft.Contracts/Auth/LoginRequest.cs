namespace CostCraft.Contracts.Auth;

public record LoginRequest(
    string UserName,
    string Password);
