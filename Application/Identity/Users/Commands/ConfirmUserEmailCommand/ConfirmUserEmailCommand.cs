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

            private readonly IUserManager _userManager;

            public ConfirmUserEmailCommandHandler(IUserManager userManager)
            {
                _userManager = userManager;
            }

            public async Task<Unit> Handle(ConfirmUserEmailCommand request, CancellationToken cancellationToken)
            {
                await _userManager.ActivateAccount(request.SecurityStamp, request.Id);

                return Unit.Value;
            }
        }
    }
}
