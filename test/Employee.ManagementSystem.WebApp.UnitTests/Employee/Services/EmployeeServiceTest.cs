using Employee.ManagementSystem.Core.Models;
using Employee.ManagementSystem.Data;
using Employee.ManagementSystem.WebApp.Data.Employee.Interfaces;
using Employee.ManagementSystem.WebApp.Data.Employee.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Employee.ManagementSystem.WebApp.UnitTests.Employee.Services;

public class EmployeeServiceTest
{
    private readonly Mock<IEmployeeService> _employeeServiceMock = new();
    
    public EmployeeServiceTest()
    {
        
    }

    [Fact]
    public void Should_Get_Value()
    {
        _employeeServiceMock
            .Setup(x => x.Get((It.IsAny<int>())))
            .ReturnsAsync(new Core.Models.Employee());
    }

    [Fact]
    public async void Create_Employee_Via_Context()
    {
        var mockSet = new Mock<DbSet<Core.Models.Employee>>();
        var mockContext = new Mock<EmployeeContext>();
        mockContext.Setup(m => m.Employees)
            .Returns(mockSet.Object);

        var service = new EmployeeService(mockContext.Object);
        Core.Models.Employee employee = new Core.Models.Employee
        {
            Id = 1,
            Name = "test",
            Email = "",
            DateOfBirth = DateTime.Now.Subtract(new TimeSpan(3650, 0, 0, 0)),
            Department = new Department() { Id = 1, Name = "IT Deparment" }
        };
        await service.Create(employee);
        var expectedId = service.Get(employee.Id).Id;
        
        Assert.Equal(employee.Id, expectedId);
    }
}