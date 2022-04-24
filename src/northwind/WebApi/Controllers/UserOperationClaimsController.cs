using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Dtos;
using Core.Security.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        IMediator _mediator;

        public UserOperationClaimsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddUserOperationClaim([FromBody] UserOperationClaimToAddDto userOperationClaimToAddDto)
        {

            CreateUserOperationClaimCommand createUserOperationClaimCommand = new CreateUserOperationClaimCommand
            {
                userOperationClaimToAddDto = userOperationClaimToAddDto
            };


            CreatedUserOperationClaimDto createdUserOperationClaimDto = await _mediator.Send(createUserOperationClaimCommand);

            return Created("", createdUserOperationClaimDto);


        }
    }
}
