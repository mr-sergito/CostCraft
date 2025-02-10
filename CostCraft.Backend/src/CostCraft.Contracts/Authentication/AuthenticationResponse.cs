namespace CostCraft.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string UserName,
    string PreferredCurrency,
    string Token);
