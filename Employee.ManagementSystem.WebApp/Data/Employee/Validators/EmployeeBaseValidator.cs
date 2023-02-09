using Employee.ManagementSystem.Shared.Employee.InputModels;
using FluentValidation;

namespace Employee.ManagementSystem.WebApp.Data.Employee.Validators;

public class EmployeeBaseValidator<T> : AbstractValidator<T> where T : EmployeeBaseInputModel
{
    public EmployeeBaseValidator()
    {
        RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(100);
        
        RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .EmailAddress();

        // DateOfBirth less than 5 years
        RuleFor(x => x.DateOfBirth).Cascade(CascadeMode.Stop)
            .LessThanOrEqualTo(DateTime.Now.Subtract(new TimeSpan(43800, 0, 0)));
        
        RuleFor(x => x.DepartmentId).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .GreaterThanOrEqualTo(1);
    }
}