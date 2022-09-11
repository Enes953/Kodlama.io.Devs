using Application.Features.Githubs.Dtos;
using Application.Features.Githubs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Commands.UpdateGithub
{
    public class UpdateGithubCommandHandler : IRequestHandler<UpdateGithubCommand, UpdatedGithubDto>
    {
        private readonly IGithubRepository _githubRepository;
        private readonly IMapper _mapper;
        private readonly GithubBusinessRules _businessRules;

        public UpdateGithubCommandHandler(IGithubRepository githubRepository, IMapper mapper, GithubBusinessRules businessRules)
        {
            _githubRepository = githubRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<UpdatedGithubDto> Handle(UpdateGithubCommand request, CancellationToken cancellationToken)
        {
            
            await _businessRules.UserShouldExistWhenRequested(request.UserId);

            Github mappedGithub = _mapper.Map<Github>(request);
            Github updatedGithub = await _githubRepository.UpdateAsync(mappedGithub);

            UpdatedGithubDto updatedGithubDto =_mapper.Map<UpdatedGithubDto>(updatedGithub);

            return updatedGithubDto;
        }
    }
}