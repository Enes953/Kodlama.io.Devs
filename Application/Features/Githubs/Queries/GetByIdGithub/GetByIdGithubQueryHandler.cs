using Application.Features.Githubs.Dtos;
using Application.Features.Githubs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Queries.GetByIdGithub
{
    public class GetByIdGithubQueryHandler : IRequestHandler<GetByIdGithubQuery, GithubGetByIdDto>
    {
        private readonly IMapper _mapper;
        private readonly IGithubRepository _githubRepository;
        private readonly GithubBusinessRules _githubBusinessRules;
        public GetByIdGithubQueryHandler(IMapper mapper, IGithubRepository githubRepository, GithubBusinessRules githubBusinessRules)
        {
            _mapper = mapper;
            _githubRepository = githubRepository;
            _githubBusinessRules = githubBusinessRules;
        }

        public async Task<GithubGetByIdDto> Handle(GetByIdGithubQuery request, CancellationToken cancellationToken)
        {
            Github? github = await _githubRepository.Query().Include(t => t.User).FirstOrDefaultAsync(x => x.Id == request.Id);
            _githubBusinessRules.GithubShouldExistWhenRequested(github);

            GithubGetByIdDto mappedGithubGetByIdDto = _mapper.Map<GithubGetByIdDto>(github);
            return mappedGithubGetByIdDto;
        }
    }
}
