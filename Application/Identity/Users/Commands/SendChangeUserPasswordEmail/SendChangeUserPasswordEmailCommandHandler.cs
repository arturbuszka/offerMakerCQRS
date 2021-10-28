using MediatR;
using OfferMakerForCggCQRS.Infrastructure.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.SendChangeUserPasswordEmail
{
    public class SendChangeUserPasswordEmailCommandHandler : IRequestHandler<SendChangeUserPasswordEmailCommand>
    {
        private readonly IUserManager _userManager;
        public SendChangeUserPasswordEmailCommandHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(SendChangeUserPasswordEmailCommand request, CancellationToken cancellationToken)
        {
            await _userManager.SendChangePasswordEmail(request.Email);

            return Unit.Value;
        }
    }
}
