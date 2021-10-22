using MediatR;
using OfferMakerForCggCQRS.Application.Identity.Users.Commands.LoginUserCommand;
using OfferMakerForCggCQRS.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Users.Commands.LoginUserCommand
{
    public class LoginUserCommand : IRequest<AuthResponseModel>
    {
        public string UserName { get; set; }

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

}
