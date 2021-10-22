using MediatR;
using OfferMakerForCggCQRS.Infrastructure.Identity;
using OfferMakerForCggCQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.ConfirmUserEmailCommand
{
    public class ConfirmUserEmailCommand : IRequest
    {
        public string SecurityStamp { get; set; }
        public string Id { get; set; }

        public class ConfirmUserEmailCommandHandler : IRequestHandler<ConfirmUserEmailCommand>
        {

            private readonly ApplicationDbContext _context;

            public ConfirmUserEmailCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ConfirmUserEmailCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

                if ( user == null || user.SecurityStamp != request.SecurityStamp)
                {

                }

                user.EmailConfirmed = true;
                user.SecurityStamp = Guid.NewGuid().ToString();

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
