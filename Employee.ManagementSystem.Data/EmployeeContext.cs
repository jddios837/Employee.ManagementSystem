using Microsoft.EntityFrameworkCore;
using Employee.ManagementSystem.Core.Models;

namespace Employee.ManagementSystem.Data;

public class EmployeeContext : DbContext
{
    public DbSet<Core.Models.Employee> Employees { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;

    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
    {
        
    }
}