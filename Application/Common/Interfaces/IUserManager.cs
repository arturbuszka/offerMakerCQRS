using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Infrastructure.Identity
{
    public interface IUserManager
    {
        Task ChangePassword(string password, string securityStamp, string userId);
        Task SendChangePasswordEmail(string userEmail);
        Task ActivateAccount(string securityStamp, string userId);
        Task<IdentityResult> CreateUserAsync(string userName, string userEmail, string password, string userRole);
        Task<string> LoginAsync(string userName);
    }
}
