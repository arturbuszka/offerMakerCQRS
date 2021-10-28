using MediatR;

namespace OfferMakerForCggCQRS.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductMenuCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
