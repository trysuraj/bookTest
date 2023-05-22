using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Core.Models.Dtos
{
    public class MappedProfile : Profile
    {
        public MappedProfile()
        {
            CreateMap<UserDto, AppUser>().ReverseMap();
        }
    }
}
