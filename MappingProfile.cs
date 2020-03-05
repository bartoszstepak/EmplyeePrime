using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crud_2.Models;

namespace crud_2
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }

    }
}
