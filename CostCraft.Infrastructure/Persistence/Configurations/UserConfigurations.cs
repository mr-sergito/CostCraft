using CostCraft.Domain.ProductAggregate.Enums;
using CostCraft.Domain.UserAggregate;
using CostCraft.Domain.UserAggregate.Enums;
using CostCraft.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostCraft.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
        ConfigureProductIdsTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.CreateFromGuid(value));

        builder.Property(m => m.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.Password)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.PreferredCurrency)
            .IsRequired()
            .HasConversion(
                    unit => unit.ToString(),
                    value => Enum.Parse<Currency>(value));
    }

    private void ConfigureProductIdsTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(m => m.ProductIds, prb =>
        {
            prb.ToTable("UserProductIds");

            prb.WithOwner().HasForeignKey("UserId");

            prb.HasKey("Id");

            prb.Property(d => d.Value)
                .IsRequired()
                .HasColumnName("ProductId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(User.ProductIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
