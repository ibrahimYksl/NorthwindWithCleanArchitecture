using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.Create
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
    {
       public CreateOperationClaimDto createOperationClaimDto { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {

            IOperationClaimRepository _operationClaimRepository;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {

                OperationClaim operationClaim = new OperationClaim
                { Name = request.createOperationClaimDto.Name };

                OperationClaim addedClaim = await _operationClaimRepository.AddAsync(operationClaim);
                CreatedOperationClaimDto createdOperationClaimDto = new CreatedOperationClaimDto { Name = request.createOperationClaimDto.Name };
                return createdOperationClaimDto;

                //OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);

                //CreatedOperationClaimDto createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(await _operationClaimRepository.AddAsync(operationClaim));
                //return createdOperationClaimDto;
            }
        }

    }
}
