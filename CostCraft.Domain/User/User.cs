using CostCraft.Domain.Common.Models;
using CostCraft.Domain.Product.ValueObjects;
using CostCraft.Domain.User.Enums;
using CostCraft.Domain.User.ValueObjects;

namespace CostCraft.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    private readonly List<ProductId> _productIds = [];

    public string Username { get; }
    public string Password { get; }
    public Currency PreferredCurrency { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();

    private User(
        UserId userId,
        string username,
        string password,
        Currency preferredCurrency,
        DateTime createdAt,
        DateTime updatedAt)
        : base(userId)
    {
        Username = username;
        Password = password;
        PreferredCurrency = preferredCurrency;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static User Create(
        string username,
        string password,
        Currency preferredCurrency)
    {
        return new User(
            UserId.CreateUnique(),
            username,
            password,
            preferredCurrency,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}