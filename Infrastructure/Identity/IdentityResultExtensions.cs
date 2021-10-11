using Microsoft.AspNetCore.Identity;
using OfferMakerForCggCQRS.Application.Common.Models;
using System.Linq;


namespace OfferMakerForCggCQRS.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
