namespace Employee.ManagementSystem.Shared.Employee.InputModels;

public class EmployeeBaseInputModel
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateOfBirth { get; set; } = DateTime.Now.Subtract(new TimeSpan(43800, 0, 0));
    public int DepartmentId { get; set; }
}