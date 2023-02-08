using Employee.ManagementSystem.Data;
using Employee.ManagementSystem.WebApp.Data.Employee.Interfaces;


namespace Employee.ManagementSystem.WebApp.Data.Employee.Services;

public class EmployeeService : IEmployeeService
{
    private readonly EmployeeContext _context;

    public EmployeeService(EmployeeContext context)
    {
        _context = context;
    }
    
    public async Task<IList<Core.Models.Employee>> GetAll()
    {
        return await _context.Employees.Include(e => e.Department).ToListAsync();
    }
}