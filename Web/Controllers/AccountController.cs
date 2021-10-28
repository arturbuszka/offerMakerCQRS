using Microsoft.AspNetCore.Mvc;
using OfferMakerForCggCQRS.Application.Identity.Roles.Commands.CreateRole;
using OfferMakerForCggCQRS.Application.Identity.Users.Commands.ChangeUserPassword;
using OfferMakerForCggCQRS.Application.Identity.Users.Commands.ConfirmUserAccount;
using OfferMakerForCggCQRS.Application.Identity.Users.Commands.CreateUser;
using OfferMakerForCggCQRS.Application.Identity.Users.Commands.LoginUser;
using OfferMakerForCggCQRS.Application.Identity.Users.Commands.SendChangeUserPasswordEmail;
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

        [HttpPost("user/forgot/new/{securityStamp}/{id}")]
        public async Task<ActionResult> ChangeUserPassword([FromBody] ChangeUserPasswordCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }


        [HttpPost("user/forgot")]
        public async Task<ActionResult> SendChangeUserPasswordEmail([FromBody] SendChangeUserPasswordEmailCommand command)
        {
            await Mediator.Send(command);
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
