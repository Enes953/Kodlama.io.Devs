using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
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
    public class LoginAuthCommand:IRequest<LoginedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }
    }
    public class LoginAuthCommandHandler : IRequestHandler<LoginAuthCommand, LoginedDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        public LoginAuthCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<LoginedDto> Handle(LoginAuthCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.AuthLoginEmailCheck(request.UserForLoginDto.Email);
            User user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

            var createdAccessToken = await _authService.CreateAccessToken(user);
            var createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
            var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            return new LoginedDto()
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken
            };
        }
    }
}
