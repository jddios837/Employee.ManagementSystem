namespace Employee.ManagementSystem.WebApp.Data.Employee.Interfaces;

public interface IEmployeeService
{
    public Task<IList<Core.Models.Employee>> GetAll();
}