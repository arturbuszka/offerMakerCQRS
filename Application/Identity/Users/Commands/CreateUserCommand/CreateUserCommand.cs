using MediatR;
using OfferMakerForCggCQRS.Application.Common.Models;
using OfferMakerForCggCQRS.Infrastructure.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<Result>
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; } = "Admin";

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IUserManager _userManager;

            public CreateUserCommandHandler(IUserManager userManager)
            {
                _userManager = userManager;
            }

            public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
               var result =  await _userManager.CreateUserAsync(request.UserName, request.UserEmail, request.UserRole);

                return result.Result;
            }
        }
    }
}
