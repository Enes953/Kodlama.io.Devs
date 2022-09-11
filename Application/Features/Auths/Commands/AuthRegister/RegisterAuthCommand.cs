using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using AutoMapper;
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

namespace Application.Features.Auths.Commands.AuthRegister
{
    public class RegisterAuthCommand:UserForRegisterDto,IRequest<AccessToken>
    {
    }
    public class RegisterAuthCommandHandler : IRequestHandler<RegisterAuthCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly AuthBusinessRules _authBusinessRules;

        public RegisterAuthCommandHandler(IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _authBusinessRules = authBusinessRules;
        }
        public async Task<AccessToken> Handle(RegisterAuthCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.AuthRegisterNameCanNotBeDuplicatedWhenInserted(request.Email);

            Byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password,out passwordHash,out passwordSalt);

            User user = _mapper.Map<User>(request);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = true;

            User newUser = await _userRepository.AddAsync(user);
            var token = _tokenHelper.CreateToken(newUser, new List<OperationClaim>());
            return token;
        }
    }
}
