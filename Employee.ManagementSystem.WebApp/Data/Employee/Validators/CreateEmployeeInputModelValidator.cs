using Employee.ManagementSystem.Shared.Employee.InputModels;
using FluentValidation;

namespace Employee.ManagementSystem.WebApp.Data.Employee.Validators;

public class CreateEmployeeInputModelValidator : EmployeeBaseValidator<CreateEmployeeInputModel>
{
    public CreateEmployeeInputModelValidator() : base()
    {
    }
}