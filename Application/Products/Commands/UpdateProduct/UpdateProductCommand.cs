using MediatR;

namespace OfferMakerForCggCQRS.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal PriceEach { get; set; }
        public string Description { get; set; }
        public int OfferId { get; set; }
    }
}
