using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        private readonly IMapper _mapper;

        public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _operationClaimBusinessRules = operationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _operationClaimBusinessRules.NameCanNotBeDuplicatedWhenInserted(request.Name);
            await _operationClaimBusinessRules.OperationClaimIdShouldBeExist(request.Id);

            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
            var mappedOperationClaim = _mapper.Map(request, operationClaim);
            var updatedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
            var mappedUpdatedOperationClaim = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
            return mappedUpdatedOperationClaim;

        }
    }
}