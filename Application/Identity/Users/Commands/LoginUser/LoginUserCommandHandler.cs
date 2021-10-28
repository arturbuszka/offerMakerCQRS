using MediatR;
using OfferMakerForCggCQRS.Infrastructure.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponseModel>
    {
        private readonly IUserManager _userManager;

        public LoginUserCommandHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthResponseModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userManager.LoginAsync(request.UserName);

            return new AuthResponseModel() { IsAuthSuccessful = true, Token = result };
        }
    }
}
