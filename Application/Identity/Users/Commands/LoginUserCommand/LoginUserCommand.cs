using MediatR;
using OfferMakerForCggCQRS.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Users.Commands.LoginUserCommand
{
    public class LoginUserCommand : IRequest<string>
    {
        public string UserName { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
        {
            private readonly IUserManager _userManager;

            public LoginUserCommandHandler(IUserManager userManager)
            {
                _userManager = userManager;
            }

            public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var result = await _userManager.LoginAsync(request.UserName);

                return result;

            }
        }
    }

}
