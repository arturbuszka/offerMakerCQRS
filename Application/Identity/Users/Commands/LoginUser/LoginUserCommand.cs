using MediatR;

namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AuthResponseModel>
    {
        public string UserName { get; set; }
    }
}
