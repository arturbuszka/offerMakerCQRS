using MediatR;

namespace OfferMakerForCggCQRS.Application.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQuery : IRequest<ClientDetailVm>
    {
        public int Id { get; set; }
    }
}
