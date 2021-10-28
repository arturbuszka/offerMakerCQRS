using MediatR;

namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : IRequest
    {
        public string UserId { get; set; }
        public string SecurityStamp { get; set; }
        public string Password { get; set; }

    }
}
