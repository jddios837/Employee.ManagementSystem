using Employee.ManagementSystem.Shared.Employee.InputModels;

namespace Employee.ManagementSystem.Data.Employee.AutoMapperProfiles;

public class EmployeeMapperProfile : Profile
{
    public EmployeeMapperProfile()
    {
        CreateMap<CreateEmployeeInputModel, Core.Models.Employee>();
    }
}