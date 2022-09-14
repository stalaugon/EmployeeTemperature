using AutoMapper;
using EmployeeTemperature.Domain.Dtos;
using EmployeeTemperature.Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Services.AutoMapper
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Temperature, TemperatureDto>();

            CreateMap<EmployeeDto, Employee>();
            CreateMap<TemperatureDto, Temperature>();

            CreateMap<Temperature, EmployeeTemperatureDto>()
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(m => m.Employee.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(m => m.Employee.LastName))
                    .ForMember(dest => dest.EmployeeNumber, opt => opt.MapFrom(m => m.Employee.EmployeeNumber));

        }
    }
}
