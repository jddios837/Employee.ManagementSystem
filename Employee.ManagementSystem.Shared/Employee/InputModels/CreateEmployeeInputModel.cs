namespace Employee.ManagementSystem.Shared.Employee.InputModels;

public class CreateEmployeeInputModel
{
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
    
    public int DepartmentId { get; set; }
}