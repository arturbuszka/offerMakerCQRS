using MediatR;
using Microsoft.AspNetCore.Identity;

namespace OfferMakerForCggCQRS.Application.Identity.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<IdentityResult>
    {
        public string Name { get; set; }
        public string Id { get; set; }

    }
}
