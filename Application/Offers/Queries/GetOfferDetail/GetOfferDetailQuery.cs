using MediatR;
using OfferMakerForCggCQRS.Application.Common.Mappings;

namespace OfferMakerForCggCQRS.Application.Offers.Queries.GetOfferDetail
{
    public class GetOfferDetailQuery : IRequest<OfferDetailDto>
    {
        public int Id { get; set; }
    }
}
