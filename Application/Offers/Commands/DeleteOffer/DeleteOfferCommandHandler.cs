using MediatR;
using OfferMakerForCggCQRS.Application.Common.Exceptions;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Commands.DeleteOffer
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand>
    {
        private readonly IOffermakerDbContext _context;

        public DeleteOfferCommandHandler(IOffermakerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Offers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

            _context.Offers.Remove(entity);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
