using MediatR;
using Microsoft.AspNetCore.Identity;

namespace OfferMakerForCggCQRS.Application.Identity.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<IdentityResult>
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; } = "Admin";
    }
}
