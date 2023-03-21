using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Employee.ManagementSystem.Core.Models;

[ExcludeFromCodeCoverage]
public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(2000)]
    public string Description { get; set; } = null!;
    
    public DateTime CreationTime { get; set; }

    public string Image { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}