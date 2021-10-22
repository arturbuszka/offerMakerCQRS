using MediatR;
using Microsoft.AspNetCore.Identity;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using OfferMakerForCggCQRS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Identity.Roles.Commands.CreateRoleCommand
{
    public class CreateRoleCommand : IRequest<IdentityResult>
    {
        public string Name { get; set; }
        public string Id { get; set; }

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
}
