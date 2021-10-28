using MediatR;

namespace OfferMakerForCggCQRS.Application.Offers.Commands.DeleteOffer
{
    public class DeleteOfferCommand : IRequest
    {
        public int Id { get; set; }
    }
}
