using OfferMakerForCggCQRS.Application.Common.Models;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Infrastructure.Identity
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string userEmail, string userRole);
        Task<string> LoginAsync(string userName);


    }
}
