using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
        }
        public async Task UserIdAndOperationClaimIdCanNotBeDuplicatedWhenRequest(int userId,int operationClaimId)
        {
            var operationClaim = await _userOperationClaimRepository.GetAsync(o => o.UserId == userId && o.OperationClaimId == operationClaimId);
            if (operationClaim != null) throw new BusinessException("User id and operation claim id can not be duplicated");
        }
        public async Task UserOperationClaimIdShouldBeExist(int id)
        {
            var userOperationCalim = await _userOperationClaimRepository.GetListAsync(o => o.Id == id);
            if (userOperationCalim == null) throw new BusinessException("Operation Claim id not exists");
        }
        public void OperationClaimShouldExistWhenRequested(UserOperationClaim userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("User Operation claim does not have any records");
        }
        public async Task CheckIfUserExists(int userId)
        {
            var user = await _userRepository.GetAsync(x => x.Id == userId);
            if (user == null) throw new BusinessException("User does not exists");
        }
        public async Task CheckIfOperationClaimExists(int operationClaimId)
        {
            var user = await _operationClaimRepository.GetAsync(o => o.Id == operationClaimId);
            if (user == null) throw new BusinessException("Operation claim does not exists");
        }
    }
}
