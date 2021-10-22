using MediatR;
using OfferMakerForCggCQRS.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.SendChangeUserPasswordCommand
{
    public class SendChangeUserPasswordCommand : IRequest
    {
        public string Email { get; set; }


        public class SendChangeUserPasswordCommandHandler : IRequestHandler<SendChangeUserPasswordCommand>
        {


            private readonly IUserManager _userManager;

            public SendChangeUserPasswordCommandHandler(IUserManager userManager)
            {
                _userManager = userManager;
            }

            public async Task<Unit> Handle(SendChangeUserPasswordCommand request, CancellationToken cancellationToken)
            {
                await _userManager.SendChangePasswordEmail(request.Email);

                return Unit.Value;
            }
        }

    }
}
