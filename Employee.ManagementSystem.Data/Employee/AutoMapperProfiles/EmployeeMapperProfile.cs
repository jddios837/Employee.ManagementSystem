using Employee.ManagementSystem.Core.Models;
using Employee.ManagementSystem.Shared.Employee.InputModels;

namespace Employee.ManagementSystem.Data.Employee.AutoMapperProfiles;

public class EmployeeMapperProfile : Profile
{
    public EmployeeMapperProfile()
    {
        CreateMap<CreateEmployeeInputModel, Core.Models.Employee>()
            .ForMember(dest => dest.Department,
                opt =>
                    opt.MapFrom(src => new Department() { Id = src.DepartmentId }));
        
        CreateMap<UpdateEmployeeInputModel, Core.Models.Employee>()
            .ForMember(dest => dest.Department,
                opt =>
                    opt.MapFrom(src => new Department() { Id = src.DepartmentId }));
        
        CreateMap<Core.Models.Employee, UpdateEmployeeInputModel>()
            .ForMember(dest => dest.DepartmentId,
                opt =>
                    opt.MapFrom(src => src.Department.Id));
    }
}