using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Rules
{
    public class GithubBusinessRules
    {
        private readonly IGithubRepository _githubRepository;
        private readonly IUserRepository _userRepository;

        public GithubBusinessRules(IGithubRepository githubRepository, IUserRepository userRepository)
        {
            _githubRepository = githubRepository;
            _userRepository = userRepository;
        }

        public async Task GithubShouldExistWhenRequested(int id)
        {
            Github? github = await _githubRepository.GetAsync(g => g.Id == id);
            if (github == null) throw new BusinessException("Requested technology does not exist.");
        }

        public async Task UserShouldExistWhenRequested(int userUd)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == userUd);
            if (user == null) throw new BusinessException("Requested user does not exist.");
        }

        public async Task GithubNameCanNotBeDuplicatedWhenInserted(int userId)
        {
            IPaginate<Github> result = await _githubRepository.GetListAsync(g => g.UserId == userId);
            if (result.Items.Any()) throw new BusinessException("Github user id exists.");
        }
    }
}
