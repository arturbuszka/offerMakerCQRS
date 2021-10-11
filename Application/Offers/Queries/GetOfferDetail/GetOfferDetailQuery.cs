using MediatR;
using OfferMakerForCggCQRS.Application.Common.Mappings;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferDetail
{
    public class GetOfferDetailQuery : IRequest<OfferDetailVm>
    {
        public int Id { get; set; }
    }
}
