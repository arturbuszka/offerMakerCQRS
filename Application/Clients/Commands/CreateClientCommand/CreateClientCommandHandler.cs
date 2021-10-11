using MediatR;
using OfferMakerForCggCQRS.Domain.Entities;
using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Clients.Commands.CreateClientCommand
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IOffermakerDbContext _context;

        public CreateClientCommandHandler(IOffermakerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = new Client
            {
                Id = request.Id,
                Name = request.Name,
                City = request.City,
                Street = request.Street,
                PostalCode = request.PostalCode,
                Nip = request.Nip,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };

            _context.Clients.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
