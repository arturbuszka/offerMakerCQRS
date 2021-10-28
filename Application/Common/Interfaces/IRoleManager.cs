using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Interfaces
{
    public interface IRoleManager
    {
        Task<IdentityResult> CreateRoleAsync(string name, string id);
    }
}
