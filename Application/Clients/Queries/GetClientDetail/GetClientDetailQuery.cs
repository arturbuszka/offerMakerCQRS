using MediatR;

namespace OfferMakerForCggCQRS.Application.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQuery : IRequest<ClientDetailDto>
    {
        public int Id { get; set; }
    }
}
