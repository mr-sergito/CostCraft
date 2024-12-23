using System.ComponentModel.DataAnnotations;

namespace CostCraft.Api.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public Currency UserCurrency { get; set; }

        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
