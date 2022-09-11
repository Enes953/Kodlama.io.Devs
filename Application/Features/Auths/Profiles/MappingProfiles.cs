using Application.Features.Auths.Commands.AuthLogin;
using Application.Features.Auths.Commands.AuthRegister;
using AutoMapper;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisterAuthCommand>().ReverseMap();
            CreateMap<User, LoginAuthCommand>().ReverseMap();
        }
    }
}
