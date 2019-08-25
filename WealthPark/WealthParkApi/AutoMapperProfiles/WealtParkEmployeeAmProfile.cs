using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Domain.Entities;
using WealthParkApi.Models;

namespace WealthParkApi.AutoMapperProfiles
{
    public class WealtParkEmployeeAmProfile : Profile
    {
        public WealtParkEmployeeAmProfile()
        {

            // Employee => EmployeeDto
            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.FullName, opts => opts.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // CreateEmployeeDto => Employee
            CreateMap<CreateEmployeeDto, Employee>();

            // UpdateEmployeeDto => Employee
            CreateMap<UpdateEmployeeDto, Employee>();

            // Just for compying values
            CreateMap<Employee, Employee>().ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
