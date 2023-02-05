using System.ComponentModel.DataAnnotations;

namespace Employee.ManagementSystem.Core.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(40)]
    public string? Name { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Email { get; set; }

    public DateTime? DateOfBirth { get; set; }
    
    public virtual Department Department { get; set; }
}