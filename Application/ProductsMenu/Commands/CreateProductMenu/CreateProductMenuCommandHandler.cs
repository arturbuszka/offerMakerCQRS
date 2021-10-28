using MediatR;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Products.Commands.CreateProduct
{
    public class CreateProductMenuCommandHandler : IRequestHandler<CreateProductMenuCommand, int>
    {
        private readonly IOffermakerDbContext _context;

        public CreateProductMenuCommandHandler(IOffermakerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductMenuCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProductMenu
            {
                Id = request.Id,
                Name = request.Name,
            };

            _context.ProductsMenu.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
