using MediatR;
using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Products.Commands.UpdateProductCommand
{

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IOffermakerDbContext _context;

        public UpdateProductCommandHandler(IOffermakerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.SingleOrDefaultAsync(p => p.Id == request.Id);


            entity.Name = request.Name;
            entity.OfferId = request.OfferId;
            entity.PriceEach = request.PriceEach;
            entity.Quantity = request.Quantity;
            entity.Description = entity.Description;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
