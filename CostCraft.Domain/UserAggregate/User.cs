using CostCraft.Domain.Common.Models;
using CostCraft.Domain.ProductAggregate.ValueObjects;
using CostCraft.Domain.UserAggregate.Enums;
using CostCraft.Domain.UserAggregate.ValueObjects;

namespace CostCraft.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private readonly List<ProductId> _productIds = [];

    public string Username { get; private set; }
    public string Password { get; private set; }
    public Currency PreferredCurrency { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

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

#pragma warning disable CS8618
    private User()
    {

    }
#pragma warning restore CS8618
}