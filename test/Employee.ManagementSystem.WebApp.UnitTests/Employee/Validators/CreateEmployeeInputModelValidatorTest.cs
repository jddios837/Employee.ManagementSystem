using Employee.ManagementSystem.Shared.Employee.InputModels;
using Employee.ManagementSystem.WebApp.Data.Employee.Validators;
using FluentValidation.TestHelper;

namespace Employee.ManagementSystem.WebApp.UnitTests.Employee.Validators;

public class CreateEmployeeInputModelValidatorTest
{
    private readonly CreateEmployeeInputModelValidator _validator;
    private readonly CreateEmployeeInputModel _model;

    public CreateEmployeeInputModelValidatorTest()
    {
        _validator = new CreateEmployeeInputModelValidator();
        _model = new CreateEmployeeInputModel();
    }

    [Fact]
    public void Should_Have_Name_Error_For_Empty_Name()
    {
        _model.Name = "";
        var result = _validator.TestValidate(_model);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }
    
    [Fact]
    public void Should_Have_Name_Error_For_MaxLenght_Name()
    {
        _model.Name = new string('s', 101);
        var result = _validator.TestValidate(_model);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }
    
    [Fact]
    public void Should_Not_Have_Name_Error_For_MaxLenght_Name()
    {
        _model.Name = new string('s', 80);
        var result = _validator.TestValidate(_model);

        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }
    
    [Fact]
    public void Should_Have_Email_Error_For_Empty_Email()
    {
        _model.Email = "";
        var result = _validator.TestValidate(_model);

        result.ShouldHaveValidationErrorFor(x => x.Email);
    }
    
    [Fact]
    public void Should_Have_Email_Error_For_Invalid_Email()
    {
        _model.Name = "test&email,com";
        var result = _validator.TestValidate(_model);

        result.ShouldHaveValidationErrorFor(x => x.Email);
    }
    
    [Fact]
    public void Should_Not_Have_Email_Error_For_Invalid_Email()
    {
        _model.Name = "test@email.com";
        var result = _validator.TestValidate(_model);

        result.ShouldHaveValidationErrorFor(x => x.Email);
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Should_Have_DepartmentId_Error_For_Invalid_DepartmentId(int value)
    {
        _model.DepartmentId = value;
        var result = _validator.TestValidate(_model);

        result.ShouldHaveValidationErrorFor(x => x.DepartmentId);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Should_Not_Have_DepartmentId_Error_For_Valid_DepartmentId(int value)
    {
        _model.DepartmentId = value;
        var result = _validator.TestValidate(_model);

        result.ShouldNotHaveValidationErrorFor(x => x.DepartmentId);
    }
}