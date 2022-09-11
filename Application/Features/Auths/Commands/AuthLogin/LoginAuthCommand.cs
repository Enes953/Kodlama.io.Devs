using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.AuthLogin
{
    public class LoginAuthCommand:UserForLoginDto,IRequest<AccessToken>
    {
    }
    public class LoginAuthCommandHandler : IRequestHandler<LoginAuthCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        public LoginAuthCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<AccessToken> Handle(LoginAuthCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.AuthLoginEmailCheck(request.Email);

            User user = await _userRepository.GetAsync(u => u.Email == request.Email);
            if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException("The password you entered is incorrect.");

            IPaginate<UserOperationClaim> userGetClaims = await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                include: i => i.Include(i => i.OperationClaim));

            AccessToken accessToken = _tokenHelper.CreateToken(user, userGetClaims.Items.Select(u => u.OperationClaim).ToList());

            return accessToken;
        }
    }
}
