namespace CostCraft.Contracts.Authentication;

public record RegisterRequest(
    string Username,
    string Password);
