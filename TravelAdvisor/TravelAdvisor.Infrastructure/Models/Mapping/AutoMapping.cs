using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Migrations.Models;

namespace TravelAdvisor.Infrastructure.Models.Mapping
{
   public class AutoMapping : Profile
    {
        public AutoMapping()
        {
         
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>().ForMember(dest => dest.Password, opt => opt.Ignore());



        }

    }
}
