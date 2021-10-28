using MediatR;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IOffermakerDbContext _context;

        public CreateProductCommandHandler(IOffermakerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Id = request.Id,
                Name = request.Name,
                PriceEach = request.PriceEach,
                Quantity = request.Quantity,
                Description = request.Description,
                OfferId = request.OfferId
            };

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
