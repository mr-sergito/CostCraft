using CostCraft.Domain.Common.Models;
using CostCraft.Domain.ProductAggregate.ValueObjects;
using CostCraft.Domain.UserAggregate.Enums;
using CostCraft.Domain.UserAggregate.ValueObjects;

namespace CostCraft.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private readonly List<ProductId> _productIds = [];

    public string UserName { get; private set; }
    public string Password { get; private set; }
    public Currency PreferredCurrency { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();

    private User(
        UserId userId,
        string userName,
        string password,
        Currency preferredCurrency,
        DateTime createdAt,
        DateTime updatedAt)
        : base(userId)
    {
        UserName = userName;
        Password = password;
        PreferredCurrency = preferredCurrency;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

#pragma warning disable CS8618
    private User()
    {

    }
#pragma warning restore CS8618

    public static User Create(
        string userName,
        string password,
        Currency preferredCurrency)
    {
        return new User(
            UserId.CreateUnique(),
            userName,
            password,
            preferredCurrency,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}