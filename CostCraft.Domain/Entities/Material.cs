using System.ComponentModel.DataAnnotations;

namespace CostCraft.Domain.Entities;

public class Material
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal PurchasedAmount { get; set; }

    [Required]
    public MeasurementUnit PurchasedUnit { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal PurchasedPrice { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal UsedAmount { get; set; }

    [Required]
    public MeasurementUnit UsedUnit { get; set; }

    [Required]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}
