using MediatR;

namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.ConfirmUserAccount
{
    public class ConfirmUserEmailCommand : IRequest
    {
        public string SecurityStamp { get; set; }
        public string Id { get; set; }

    }
}
