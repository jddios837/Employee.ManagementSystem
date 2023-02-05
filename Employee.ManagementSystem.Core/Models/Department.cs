using System.ComponentModel.DataAnnotations;

namespace Employee.ManagementSystem.Core.Models;

public class Department
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
}