using Microsoft.AspNetCore.Authorization;
using OfferMakerForCggCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Authorization.ResourceOperationRequirement
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Offer>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Offer resource)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read ||
                requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (resource.CreatedBy == (userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
