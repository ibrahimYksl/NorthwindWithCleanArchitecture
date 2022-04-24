using Application.Features.Authorizations.Dtos;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
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

namespace Application.Features.Authorizations.Command.Register
{
    public class RegisterCommand : IRequest<RegisteredDto>
    {
        public UserForRegisterDto userForRegisterDto { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {

            IUserRepository _userRepository;
            IMapper _mapper;
            IAuthService _authService;

            public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authService = authService;
            }

            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.userForRegisterDto.Password, out passwordHash, out passwordSalt);
                User user = new User{
                    Email = request.userForRegisterDto.Email,
                    FirstName = request.userForRegisterDto.FirstName,
                    LastName = request.userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                User createdUser = await _userRepository.AddAsync(user);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

                RegisteredDto registedDto = new RegisteredDto
                {
                    AccessToken = createdAccessToken
                };
                return registedDto;
            }
        }
    }
}
