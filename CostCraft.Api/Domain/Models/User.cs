using System.ComponentModel.DataAnnotations;

namespace CostCraft.Api.Domain.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public Currency UserCurrency { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];
}
