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

namespace Application.Features.Githubs.Commands.CreateGithub
{
    public class CreateGithubHandler : IRequestHandler<CreateGithubCommand, CreatedGithubDto>
    {
        private readonly IGithubRepository _githubRepository;
        private readonly IMapper _mapper;
        private readonly GithubBusinessRules _businessRules;

        public CreateGithubHandler(IGithubRepository githubRepository, IMapper mapper, GithubBusinessRules businessRules)
        {
            _githubRepository = githubRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }
        public async Task<CreatedGithubDto> Handle(CreateGithubCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.GithubNameCanNotBeDuplicatedWhenInserted(request.UserId);
            await _businessRules.UserShouldExistWhenRequested(request.UserId);

            Github mappedGithub = _mapper.Map<Github>(request);
            Github createdGithub = await _githubRepository.AddAsync(mappedGithub);

            CreatedGithubDto createdTGithubDto = _mapper.Map<CreatedGithubDto>(createdGithub);

            return createdTGithubDto;
        }
    }
}
