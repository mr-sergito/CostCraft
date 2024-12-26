using System.ComponentModel.DataAnnotations;

namespace CostCraft.Domain.Entities;

public class Product
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    public int UnitsProduced { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Range(0, 100)]
    public decimal ProfitMarginPercentage { get; set; }

    [Required]
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = [];
    public virtual ICollection<Labor> LaborEntries { get; set; } = [];
}
