using Employee.ManagementSystem.Shared.Employee.InputModels;
using FluentValidation;

namespace Employee.ManagementSystem.WebApp.Data.Employee.Validators;

public class CreateEmployeeInputModelValidator : AbstractValidator<CreateEmployeeInputModel>
{
    public CreateEmployeeInputModelValidator()
    {
        RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(100);
        
        RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x => x.DepartmentId).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .GreaterThanOrEqualTo(1);
    }
}