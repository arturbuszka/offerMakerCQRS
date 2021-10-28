using MediatR;

namespace OfferMakerForCggCQRS.Application.Products.Commands.CreateProduct
{
    public class CreateProductMenuCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
