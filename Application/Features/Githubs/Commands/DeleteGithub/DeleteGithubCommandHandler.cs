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

namespace Application.Features.Githubs.Commands.DeleteGithub
{
    public class DeleteGithubCommandHandler : IRequestHandler<DeleteGithubCommand, DeletedGithubDto>
    {
        private readonly IGithubRepository _githubRepository;
        private readonly IMapper _mapper;
        private readonly GithubBusinessRules _businessRules;

        public DeleteGithubCommandHandler(IGithubRepository githubRepository, IMapper mapper, GithubBusinessRules businessRules)
        {
            _githubRepository = githubRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }
        public async Task<DeletedGithubDto> Handle(DeleteGithubCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.GithubShouldExistWhenRequested(request.Id);

           Github? github = await _githubRepository.GetAsync(p => p.Id == request.Id);
           Github githubLanguage = await _githubRepository.DeleteAsync(github);

           DeletedGithubDto deletedGithubDto =_mapper.Map<DeletedGithubDto>(githubLanguage);

            return deletedGithubDto;
        }
    }
}
