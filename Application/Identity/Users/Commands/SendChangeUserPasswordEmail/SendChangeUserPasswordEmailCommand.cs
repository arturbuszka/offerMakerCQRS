using MediatR;

namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.SendChangeUserPasswordEmail
{
    public class SendChangeUserPasswordEmailCommand : IRequest
    {
        public string Email { get; set; }
    }
}
