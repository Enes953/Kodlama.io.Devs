using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }
        public async Task NameCanNotBeDuplicatedWhenInserted(string name)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Name == name);
            if (operationClaim != null) throw new BusinessException("There is such an email in the system.");
        }
        public async Task OperationClaimIdShouldBeExist(int id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == id);
            if (operationClaim == null) throw new BusinessException("Operation Claim not exists");
        }
    }
}
