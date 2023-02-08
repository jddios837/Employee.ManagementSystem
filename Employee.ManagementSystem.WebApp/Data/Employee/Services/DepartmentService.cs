using Employee.ManagementSystem.WebApp.Data.Employee.Interfaces;

namespace Employee.ManagementSystem.WebApp.Data.Employee.Services;

public class DepartmentService : IDepartmentService
{
    private readonly EmployeeContext _context;

    public DepartmentService(EmployeeContext context)
    {
        _context = context;
    }
    
    public async Task<IList<Department>> GetAll()
    {
        return await _context.Departments.ToListAsync();
    }
}