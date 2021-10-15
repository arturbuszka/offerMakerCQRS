using MediatR;

namespace OfferMakerForCggCQRS.Application.Products.Queries.GetProductDetail
{
    public class GetProductMenuDetailQuery : IRequest<ProductMenuDetailVm>
    {
        public int Id { get; set; }
    }
}
