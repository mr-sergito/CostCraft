namespace CostCraft.Contracts.Authentication;

public record LoginRequest(
    string UserName,
    string Password);
