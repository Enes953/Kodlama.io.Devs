using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
        private readonly IMapper _mapper;

        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.UserOperationClaimIdShouldBeExist(request.Id);
            await _userOperationClaimBusinessRules.UserIdAndOperationClaimIdCanNotBeDuplicatedWhenRequest(request.UserId, request.OperationClaimId);
            await _userOperationClaimBusinessRules.CheckIfUserExists(request.UserId);
            await _userOperationClaimBusinessRules.CheckIfOperationClaimExists(request.OperationClaimId);

            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.Id == request.Id);
            UserOperationClaim? mappedUserOperationClaim = _mapper.Map(request,userOperationClaim);
            UserOperationClaim updatedUserOperationClaim= await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);
            UpdatedUserOperationClaimDto mappedUpdateUserOperationClaimDto = _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);

            return mappedUpdateUserOperationClaimDto;
        }
    }
}