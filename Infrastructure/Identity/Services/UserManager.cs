using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OfferMakerForCggCQRS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Infrastructure.Identity
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IEmailService _emailService;

        public UserManager(UserManager<ApplicationUser> userManager, AuthenticationSettings authenticationSettings, RoleManager<ApplicationRole> roleManager, IEmailService emailService)
        {
            _userManager = userManager;
            _authenticationSettings = authenticationSettings;
            _roleManager = roleManager;
            _emailService = emailService;
        }

        public async Task ChangePassword(string password, string securityStamp, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null || user.SecurityStamp != securityStamp)
            {

            }

            var hashedPassword = _userManager.PasswordHasher.HashPassword(user, password);
            user.PasswordHash = hashedPassword;

            await _userManager.UpdateSecurityStampAsync(user);
        }

        public async Task SendChangePasswordEmail(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            await _emailService.ChangePasswordMail(userEmail, user.SecurityStamp, user.Id);
        }

        public async Task ActivateAccount(string securityStamp, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null || user.SecurityStamp != securityStamp)
            {

            }

            user.EmailConfirmed = true;
            await _userManager.UpdateSecurityStampAsync(user);
        }

        public async Task<IdentityResult> CreateUserAsync(string userName, string userEmail, string password,  string role)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userEmail
            };

            var hashedPassword = _userManager.PasswordHasher.HashPassword(user, password);
            user.PasswordHash = hashedPassword;

            var entity = await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, role);

            await _emailService.ActivationMail(user.Email, user.SecurityStamp, user.Id);

            return entity;
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
