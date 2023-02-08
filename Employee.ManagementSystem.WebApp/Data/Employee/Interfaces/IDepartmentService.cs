using Employee.ManagementSystem.Core.Models;

namespace Employee.ManagementSystem.WebApp.Data.Employee.Interfaces;

public interface IDepartmentService
{
    public Task<IList<Department>> GetAll();
}