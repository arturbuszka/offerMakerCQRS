using Microsoft.AspNetCore.Identity;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Infrastructure.Identity
{
    public class RoleManager : IRoleManager
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleManager(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRoleAsync(string name, string id)
        {
            var role = new ApplicationRole
            {
                Name = name,
                Id = id
            };



            var result = await _roleManager.CreateAsync(role);


            return result;
        }
    }
}
