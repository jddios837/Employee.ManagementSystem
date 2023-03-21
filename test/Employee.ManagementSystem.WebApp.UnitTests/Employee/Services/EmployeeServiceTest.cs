using Employee.ManagementSystem.Core.Models;
using Employee.ManagementSystem.Data;
using Employee.ManagementSystem.WebApp.Data.Employee.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Employee.ManagementSystem.WebApp.UnitTests.Employee.Services;

public class EmployeeServiceTest
{
    private async Task<EmployeeContext> GetDbContext()
    {
        var options = new DbContextOptionsBuilder<EmployeeContext>()
            .UseInMemoryDatabase(databaseName: "test_db")
            .Options;

        var databaseContext = new EmployeeContext(options);

        if (await databaseContext.Employees.CountAsync() == 0) 
        {
            for (int i = 1; i < 5; i++)
            {
                databaseContext.Employees.Add(new Core.Models.Employee
                {
                    Name = $"test{i}",
                    Email = $"test{i}@email.com",
                    DateOfBirth = DateTime.Now.Subtract(new TimeSpan(3650, 0, 0, 0)),
                    Department = new Department() { Id = i, Name = $"Department {i}" }
                });
                await databaseContext.SaveChangesAsync();
            } 
        }
        
        return databaseContext;
    }

    
    [Fact]
    public async void Should_Create_Employee()
    {
        //Arrange
        var employee = new Core.Models.Employee
        {
            Name = "test",
            Email = "",
            DateOfBirth = DateTime.Now.Subtract(new TimeSpan(3650, 0, 0, 0)),
            Department = new Department() { Id = 1, Name = "IT Deparment" }
        };
        var dbContext = await GetDbContext();
        var employeeService = new EmployeeService(dbContext);
        
        //Act
        var result = await employeeService.Create(employee);
        
        //Assert
        result.Should().BeGreaterOrEqualTo(1);
    }
    
    [Fact]
    public async void Should_Not_Create_Employee()
    {
        //Arrange
        var employee = new Core.Models.Employee
        {
            Name = "test1",
            Email = "test1@email.com",
            DateOfBirth = DateTime.Now.Subtract(new TimeSpan(3650, 0, 0, 0)),
            Department = new Department() { Id = 1, Name = "IT Deparment" }
        };
        var dbContext = await GetDbContext();
        var employeeService = new EmployeeService(dbContext);
        
        //Act
        var result = await employeeService.Create(employee);
        
        //Assert
        result.Should().Be(-1);
    }
    
    [Fact]
    public async void Should_Get_Employee()
    {
        //Arrange
        int employeeId = 3;
        var dbContext = await GetDbContext();
        var employeeService = new EmployeeService(dbContext);
        
        //Act
        var result = await employeeService.Get(employeeId);
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Core.Models.Employee>();
    }

    [Fact]
    public async void Should_Update_Employee()
    {
        //Arrange
        int employeeId = 3;
        var dbContext = await GetDbContext();
        var employeeService = new EmployeeService(dbContext);
        var employee = await employeeService.Get(employeeId);
        string nameExpected = "test3_mod";

        //Act
        if (employee == null) return;
        employee.Name = nameExpected;
        var result = await employeeService.Update(employeeId, employee);
        
        //Assert
        result.Name.Should().Be(nameExpected);
    }
    
    [Fact]
    public async void Should_Not_Update_Employee()
    {
        //Arrange
        int employeeId = 3;
        var dbContext = await GetDbContext();
        var employeeService = new EmployeeService(dbContext);
        var employee = await employeeService.Get(employeeId);
        string emailExpected = "test4@email.com";

        //Act
        if (employee != null)
        {
            employee.Email = emailExpected;
            var result = await employeeService.Update(employeeId, employee);
        
            //Assert
            result.Id.Should().NotBe(employeeId);
        }
    }

    [Fact]
    public async void Should_Remove_Employee()
    {
        //Arrange
        int employeeId = 3;
        var dbContext = await GetDbContext();
        var employeeService = new EmployeeService(dbContext);
        
        //Act
        await employeeService.Delete(employeeId);
        var result = await employeeService.Get(employeeId);

        //Assert
        result.Should().BeNull();
    }

    
}