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

namespace Application.Features.Githubs.Queries.GetListGithubByDynamic
{
    public class GetListGithubByDynamicQueryHandler : IRequestHandler<GetListGithubByDynamicQuery, GithubListModel>
    {
        private readonly IMapper _mapper;
        private readonly IGithubRepository _githubRepository;
        public GetListGithubByDynamicQueryHandler(IMapper mapper, IGithubRepository githubRepository)
        {
            _mapper = mapper;
            _githubRepository = githubRepository;
        }

        public async Task<GithubListModel> Handle(GetListGithubByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Github> githubs = await _githubRepository.GetListByDynamicAsync(request.Dynamic, include:
                                                      t => t.Include(c => c.User),
                                                      index: request.PageRequest.Page,
                                                      size: request.PageRequest.PageSize);
            GithubListModel mappedgithubListModel = _mapper.Map<GithubListModel>(githubs);
            return mappedgithubListModel;
        }
    }
}
