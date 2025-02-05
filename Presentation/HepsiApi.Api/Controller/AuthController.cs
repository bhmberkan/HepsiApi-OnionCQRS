using Hepsiapi.Application.Features.Auth.Command.Login;
using Hepsiapi.Application.Features.Auth.Command.RefreshToken;
using Hepsiapi.Application.Features.Auth.Command.Register;
using Hepsiapi.Application.Features.Auth.Command.Revoke;
using Hepsiapi.Application.Features.Auth.Command.RevokeAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HepsiApi.Api.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommadRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
             await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }
        
        
        //[HttpPost]
        //public async Task<IActionResult> RevokeAll(RevokeAllCommandRequest request)
        //{
        //    var response = await mediator.Send(request);
        //    return StatusCode(StatusCodes.Status200OK, response);
        //}
        
        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
          await mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
