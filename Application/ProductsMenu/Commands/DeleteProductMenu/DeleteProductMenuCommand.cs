using MediatR;

namespace OfferMakerForCggCQRS.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductMenuCommand : IRequest
    {
        public int Id { get; set; }
    }
}
