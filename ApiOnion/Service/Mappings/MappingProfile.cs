using AutoMapper;
using Domain.Entities;
using Service.DTOs.Company;
using Service.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<CompanyUpdateDto, Company>();
            CreateMap<CompanyGetByIdDto, Company>();
            CreateMap<CompanySearchDto, Company>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));
            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<EmployeeGetByIdDto, Employee>();
            CreateMap<EmployeeSearchDto, Employee>();
        }
    }
}
