using MediatR;
using OfferMakerForCggCQRS.Infrastructure.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.ConfirmUserAccount
{
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
