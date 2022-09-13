using Application.Features.Githubs.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Queries.GetListGithub
{
    public class GetListGithubQueryHandler : IRequestHandler<GetListGithubQuery, GithubListModel>
    {
        private readonly IMapper _mapper;
        private readonly IGithubRepository _githubRepository;
        public GetListGithubQueryHandler(IMapper mapper, IGithubRepository githubRepository)
        {
            _mapper = mapper;
            _githubRepository = githubRepository;
        }

        public async Task<GithubListModel> Handle(GetListGithubQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Github> githubs = await _githubRepository.GetListAsync(include:
                                              t => t.Include(t => t.User),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );

            GithubListModel mappedGithubListModel = _mapper.Map<GithubListModel>(githubs);

            return mappedGithubListModel;
        }
    }
}
