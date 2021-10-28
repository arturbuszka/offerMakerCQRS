using MediatR;
using Microsoft.AspNetCore.Identity;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Identity.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, IdentityResult>
    {
        private readonly IRoleManager _roleManager;

        public CreateRoleCommandHandler(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _roleManager.CreateRoleAsync(request.Name, request.Id);

            return result;
        }
    }
}
