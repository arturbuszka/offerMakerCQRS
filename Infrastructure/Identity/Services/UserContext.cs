using Microsoft.AspNetCore.Http;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using System.Security.Claims;


namespace OfferMakerForCggCQRS.Infrastructure.Identity
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
    }
}
