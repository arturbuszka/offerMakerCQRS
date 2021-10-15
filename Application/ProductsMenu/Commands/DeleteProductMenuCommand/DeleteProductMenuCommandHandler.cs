using MediatR;
using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Products.Commands.DeleteProductCommand
{

    public class DeleteProductMenuCommandHandler : IRequestHandler<DeleteProductMenuCommand>
    {
        private readonly IOffermakerDbContext _context;

        public DeleteProductMenuCommandHandler(IOffermakerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductMenuCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductsMenu.FindAsync(request.Id);

            _context.ProductsMenu.Remove(entity);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
