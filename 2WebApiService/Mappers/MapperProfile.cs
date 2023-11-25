using _2WebApiDomain.Entities;
using _2WebApiService.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WebApiService.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserCreationDto>().ReverseMap();
        }
    }
}
