using Microsoft.AspNetCore.Identity;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using OfferMakerForCggCQRS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Infrastructure.Identity
{
    public class RoleManagerService : IRoleManager
    {

        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleManagerService(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<(Result Result, string roleId)> CreateRoleAsync(string name, string id)
        {
            var role = new ApplicationRole
            {
                Name = name,
                Id = id
            };



            var result = await _roleManager.CreateAsync(role);


            return (result.ToApplicationResult(), role.Id);
        }
    }
}
