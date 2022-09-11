using Application.Features.Githubs.Commands.CreateGithub;
using Application.Features.Githubs.Commands.DeleteGithub;
using Application.Features.Githubs.Commands.UpdateGithub;
using Application.Features.Githubs.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Github,CreateGithubCommand>().ReverseMap();
            CreateMap<Github,CreatedGithubDto>().ReverseMap();

            CreateMap<Github,UpdateGithubCommand>().ReverseMap();
            CreateMap<Github,UpdatedGithubDto>().ReverseMap();

            CreateMap<Github, DeleteGithubCommand>().ReverseMap();
            CreateMap<Github,DeletedGithubDto>().ReverseMap();
        }
    }
}
