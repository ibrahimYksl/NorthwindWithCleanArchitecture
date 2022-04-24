using Application.Features.Authorizations.Dtos;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.CrossCuttingConserns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.Jwt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authorizations.Command.Login
{
    public class LoginCommand : IRequest<LoggedInDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }


        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInDto>
        {


            IUserRepository _userRepository;
            IAuthService _authService;

            public LoginCommandHandler(IUserRepository userRepository, IAuthService authService)
            {
                _userRepository = userRepository;
                _authService = authService;
            }

           
            public async Task<LoggedInDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {

                User user = await _userRepository.GetAsync(x => x.Email == request.UserForLoginDto.Email);


                if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt)) 
                {
                    throw new BusinessException("Parola Hatası");
                }


                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

                LoggedInDto loggedUser = new LoggedInDto { AccessToken = createdAccessToken, FirstName = user.FirstName, LastName = user.LastName };
                return loggedUser;
            }
        }

    }
}
