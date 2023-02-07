namespace Employee.ManagementSystem.Shared.Employee.InputModels;

public class CreateEmployeeInputModel
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public DateOnly DateOfBirth { get; set; }
    
    public int DepartmentId { get; set; }
}