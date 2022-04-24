using Application.Features.OperationClaims.Commands.Create;
using Application.Features.OperationClaims.Dtos;
using Core.Security.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        IMediator _mediator;

        public OperationClaimsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddClaim([FromBody] CreateOperationClaimDto createOperationClaimDto)
        {


                            CreateOperationClaimCommand createOperationClaimCommand = new CreateOperationClaimCommand
                            {
                                createOperationClaimDto = createOperationClaimDto
                            };


            CreatedOperationClaimDto createdOperationClaimDto = await _mediator.Send(createOperationClaimCommand);

            return Created("", createdOperationClaimDto);


        }


    }



}
