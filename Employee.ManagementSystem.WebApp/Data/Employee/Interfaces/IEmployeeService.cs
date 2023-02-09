namespace Employee.ManagementSystem.WebApp.Data.Employee.Interfaces;

public interface IEmployeeService
{
    public Task<IList<Core.Models.Employee>> GetAll();

    public Task<int> Create(Core.Models.Employee employee);

    public Task<Core.Models.Employee?> Get(int employeeId);

    public Task<Core.Models.Employee> Delete(int employeeId);
}