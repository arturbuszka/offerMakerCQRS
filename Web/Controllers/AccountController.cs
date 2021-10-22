using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferMakerForCggCQRS.Application.Identity.Roles.Commands.CreateRoleCommand;
using OfferMakerForCggCQRS.Application.Identity.Users.Commands.ConfirmUserEmailCommand;
using OfferMakerForCggCQRS.Application.Users.Commands.CreateUserCommand;
using OfferMakerForCggCQRS.Application.Users.Commands.LoginUserCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Web.Controllers
{
    [Route("account")]
    public class AccountController : BaseController
    {

        [HttpGet("user/{securityStamp}/{id}")]
        public async Task<ActionResult> SendUserConfirmEmail([FromRoute] string securityStamp, string id)
        {
            await Mediator.Send(new ConfirmUserEmailCommand() { SecurityStamp = securityStamp, Id = id });
            return Ok();
        }


        [HttpPost("user/new")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpPost("user/login")]
        public async Task<ActionResult> Login([FromBody] LoginUserCommand command)
        {
            var authResponse = await Mediator.Send(command);
            return Ok(authResponse);
        }

        [HttpPost("role/new")]
        public async Task<ActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
    }
}
