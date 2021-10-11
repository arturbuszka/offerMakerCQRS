using MediatR;
using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Clients.Commands.UpdateClientCommand
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IOffermakerDbContext _context;

        public UpdateClientCommandHandler(IOffermakerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Clients.FindAsync(request.Id);


            entity.Name = request.Name;
            entity.City = request.City;
            entity.Street = request.Street;
            entity.PostalCode = request.PostalCode;
            entity.Nip = request.Nip;
            entity.PhoneNumber = request.PhoneNumber;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
