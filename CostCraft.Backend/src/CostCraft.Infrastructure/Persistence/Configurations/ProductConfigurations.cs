using CostCraft.Domain.ProductAggregate;
using CostCraft.Domain.ProductAggregate.Enums;
using CostCraft.Domain.ProductAggregate.ValueObjects;
using CostCraft.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostCraft.Infrastructure.Persistence.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureProductsTable(builder);
        ConfigureMaterialsTable(builder);
        ConfigureLaborsTable(builder);
    }

    private void ConfigureProductsTable(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductId.CreateFromGuid(value));

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.UnitsProduced)
            .IsRequired();

        builder.Property(m => m.ProfitMarginPercentage)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(m => m.UserId)
            .IsRequired()
            .HasConversion(
                id => id.Value,
                value => UserId.CreateFromGuid(value));

        builder.Property(m => m.TotalCost)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(m => m.SalePrice)
            .IsRequired()
            .HasPrecision(18, 2);
    }

    private void ConfigureMaterialsTable(EntityTypeBuilder<Product> builder)
    {
        builder.OwnsMany(m => m.Materials, sb =>
        {
            sb.ToTable("Materials");

            sb.WithOwner().HasForeignKey("ProductId");

            sb.HasKey("Id", "ProductId");

            sb.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MaterialId.CreateFromGuid(value));

            sb.Property(s => s.Name)
                .HasMaxLength(100);

            sb.Property(s => s.PurchasedAmount)
                .IsRequired()
                .HasPrecision(18, 2);

            sb.Property(s => s.PurchasedUnit)
                .IsRequired()
                .HasConversion(
                        unit => unit.ToString(),
                        value => Enum.Parse<MeasurementUnit>(value));

            sb.Property(s => s.PurchasedPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            sb.Property(s => s.UsedAmount)
                .IsRequired()
                .HasPrecision(18, 2);

            sb.Property(s => s.UsedUnit)
                .IsRequired()
                .HasConversion(
                        unit => unit.ToString(),
                        value => Enum.Parse<MeasurementUnit>(value));

            sb.Property(m => m.UsedCost)
                .IsRequired()
                .HasPrecision(18, 2);
        });

        builder.Metadata.FindNavigation(nameof(Product.Materials))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureLaborsTable(EntityTypeBuilder<Product> builder)
    {
        builder.OwnsMany(m => m.Labors, sb =>
        {
            sb.ToTable("Labors");

            sb.WithOwner().HasForeignKey("ProductId");

            sb.HasKey("Id", "ProductId");

            sb.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => LaborId.CreateFromGuid(value));

            sb.Property(s => s.TimeUnit)
                .IsRequired()
                .HasConversion(
                    unit => unit.ToString(),
                    value => Enum.Parse<MeasurementUnit>(value));

            sb.Property(s => s.TimePayRate)
                .IsRequired()
                .HasPrecision(18, 2);

            sb.Property(s => s.TimeWorked)
                .IsRequired()
                .HasPrecision(18, 2);

            sb.Property(s => s.TimeCost)
                .IsRequired()
                .HasPrecision(18, 2);
        });

        builder.Metadata.FindNavigation(nameof(Product.Labors))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
