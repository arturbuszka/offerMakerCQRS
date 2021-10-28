using MediatR;
using OfferMakerForCggCQRS.Application.Common.Exceptions;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Commands.UpdateOffer
{
    public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand>
    {
        private readonly IOffermakerDbContext _context;

        public UpdateOfferCommandHandler(IOffermakerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Offers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

            var productsToRemove = _context.Products
                .AsQueryable()
                .Where(x => x.OfferId == request.Id);

            _context.Products.RemoveRange(productsToRemove);


            entity.City = request.City;
            entity.Street = request.Street;
            entity.PostalCode = request.PostalCode;
            entity.Products = request.Products;
            entity.ClientId = request.ClientId;
            entity.DateOfWork = request.DateOfWork;
            entity.Description = request.Description;
            entity.ProductsCount = request.ProductsCount;
            entity.ProductsPrice = request.ProductsPrice;


            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
