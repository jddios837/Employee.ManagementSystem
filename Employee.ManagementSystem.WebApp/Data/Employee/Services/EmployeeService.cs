﻿using System.Linq.Dynamic.Core;
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

    public async Task<int> Create(Core.Models.Employee employee)
    {
        employee.Department = _context.Departments
            .FirstOrDefault(e => e.Id == employee.Department.Id) ?? 
                              throw new InvalidOperationException();
        _context.Employees.Add(employee);
        return await _context.SaveChangesAsync();
    }

    public async Task<Core.Models.Employee> Delete(int employeeId)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId)!;
        if (employee == null) return new Core.Models.Employee();

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return employee;
    }
}