using MediatR;
using Microsoft.AspNetCore.Identity;
using OfferMakerForCggCQRS.Application.Common.Models;
using OfferMakerForCggCQRS.Infrastructure.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<IdentityResult>
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; } = "Admin";

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IdentityResult>
        {
            private readonly IUserManager _userManager;
            //private readonly IAppUserManager _userManager;

            public CreateUserCommandHandler(IUserManager userManager)
            {
                _userManager = userManager;
            }

            public async Task<IdentityResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {

                var result = await _userManager.CreateUserAsync(request.UserName, request.UserEmail, request.Password, request.UserRole);



                return result;
            }
        }
    }
}
