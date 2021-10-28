using MediatR;

namespace OfferMakerForCggCQRS.Application.Products.Queries.GetProductDetail
{
    public class GetProductMenuDetailQuery : IRequest<ProductMenuDetailDto>
    {
        public int Id { get; set; }
    }
}
