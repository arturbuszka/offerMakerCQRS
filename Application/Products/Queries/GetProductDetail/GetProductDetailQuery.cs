using MediatR;

namespace OfferMakerForCggCQRS.Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailDto>
    {
        public int Id { get; set; }
    }
}
