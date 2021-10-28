using MediatR;

namespace OfferMakerForCggCQRS.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest
    {
        public int ClientId { get; set; }
    }
}
