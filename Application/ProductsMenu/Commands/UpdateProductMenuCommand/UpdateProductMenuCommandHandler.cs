using MediatR;
using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Products.Commands.UpdateProductCommand
{

    public class UpdateProductMenuCommandHandler : IRequestHandler<UpdateProductMenuCommand>
    {
        private readonly IOffermakerDbContext _context;

        public UpdateProductMenuCommandHandler(IOffermakerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductMenuCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductsMenu.SingleOrDefaultAsync(p => p.Id == request.Id);


            entity.Name = request.Name;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
