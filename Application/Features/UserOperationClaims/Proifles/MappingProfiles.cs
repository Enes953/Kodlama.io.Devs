using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Proifles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, UserOperationClaimGetByIdDto>()
            .ForMember(c =>
                    c.FirstName,
                opt =>
                    opt.MapFrom(c => c.User.FirstName))
            .ForMember(c =>
                    c.LastName,
                opt =>
                    opt.MapFrom(c => c.User.LastName))
            .ForMember(c =>
                    c.Email,
                opt =>
                    opt.MapFrom(c => c.User.Email))
            .ForMember(c =>
                    c.OperationClaimName,
                opt =>
                    opt.MapFrom(c => c.OperationClaim.Name))
            .ReverseMap();

            CreateMap<UserOperationClaim, UserOperationClaimListDto>()
                .ForMember(c =>
                        c.FirstName,
                    opt =>
                        opt.MapFrom(c => c.User.FirstName))
                .ForMember(c =>
                        c.LastName,
                    opt =>
                        opt.MapFrom(c => c.User.LastName))
                .ForMember(c =>
                        c.Email,
                    opt =>
                        opt.MapFrom(c => c.User.Email))
                .ForMember(c =>
                        c.OperationClaimName,
                    opt =>
                        opt.MapFrom(c => c.OperationClaim.Name))
                .ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
        }
    }
}
