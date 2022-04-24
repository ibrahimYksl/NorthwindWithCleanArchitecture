using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
    {
        public UserOperationClaimToAddDto userOperationClaimToAddDto { get; set; }


        public class CreateUserOperationClaimHandler:IRequestHandler<CreateUserOperationClaimCommand,CreatedUserOperationClaimDto>
        {
            IUserOperationClaimRepository _userOperationClaimRepository;
            IMapper _mapper;

            public CreateUserOperationClaimHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request.userOperationClaimToAddDto);
                CreatedUserOperationClaimDto createdUserOperationClaimDto =  _mapper.Map<CreatedUserOperationClaimDto>(await _userOperationClaimRepository.AddAsync(userOperationClaim));
                return createdUserOperationClaimDto;



                
            }
        }
    }
}
