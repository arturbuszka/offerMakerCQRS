using MediatR;
using OfferMakerForCggCQRS.Application.Common.Exceptions;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Offers.Commands.UpdateOfferCommand
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
            var entity = await _context.Offers.FindAsync(request.OfferId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Offer), request.OfferId);
            }



            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
