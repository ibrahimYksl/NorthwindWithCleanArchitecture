using Application.Features.Authorizations.Command.Login;
using Application.Features.Authorizations.Command.Register;
using Application.Features.Authorizations.Dtos;
using Core.Security.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IMediator _mediator;

        public AuthsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new RegisterCommand
            {
                userForRegisterDto = userForRegisterDto,
            };
            RegisteredDto registeredDto = await _mediator.Send(registerCommand);
            return Created("", registeredDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)

        {

            LoginCommand loginCommand = new LoginCommand
            {
                UserForLoginDto = userForLoginDto
            };


            LoggedInDto loggedInDto = await _mediator.Send(loginCommand);
            return Created("", loggedInDto);
        }
    }
}
