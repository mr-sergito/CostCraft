using System.ComponentModel.DataAnnotations;

namespace CostCraft.Api.Domain.Models;

public class Labor
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal TimePayRate { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal TimeWorked { get; set; }

    [Required]
    public MeasurementUnit TimeUnit { get; set; }

    [Required]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}
