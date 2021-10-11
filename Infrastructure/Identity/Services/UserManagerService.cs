using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OfferMakerForCggCQRS.Application.Common.Exceptions;
using OfferMakerForCggCQRS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserManagerService(UserManager<ApplicationUser> userManager, AuthenticationSettings authenticationSettings, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _authenticationSettings = authenticationSettings;
            _roleManager = roleManager;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string userEmail, string role)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userEmail,
            };

            


            var result = await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, role);
            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<string> LoginAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);

            if (user == null)
            {
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.UserName}"),
                new Claim(ClaimTypes.Role, $"{roles.FirstOrDefault()}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpiredDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
