using System.Security.Claims;

namespace OfferMakerForCggCQRS.Application.Common.Interfaces
{
    public interface IUserContext
    {
        ClaimsPrincipal User { get; }
    }
}
