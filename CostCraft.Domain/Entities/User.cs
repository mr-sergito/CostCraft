using System.ComponentModel.DataAnnotations;

namespace CostCraft.Domain.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(100)]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    public Currency PreferredCurrency { get; set; } = Currency.EUR;

    public virtual ICollection<Product> Products { get; set; } = [];
}
