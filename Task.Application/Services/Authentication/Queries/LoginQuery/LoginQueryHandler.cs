using Application.Common.Exceptions;
using Domain.Common.Errors;
using Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Queries.LoginQuery
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, ErrorOr<LoginQueryResponce>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public LoginQueryHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration) {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<ErrorOr<LoginQueryResponce>> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null) 
                    return Errors.User.InvalidCredentials;

                if (!await _userManager.CheckPasswordAsync(user, request.Password))
                    return Errors.User.InvalidPassword;

                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var claim in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, claim));
                }
                int second = Convert.ToInt32(_configuration["JWT:ExpiryTime"]);
                var token = GenerateToken(authClaims, second);
                return new LoginQueryResponce()
                {
                    Token = token,
                    ExpiryTime = second,
                    IsSuccess = true
                };
        }

        private string GenerateToken(IEnumerable<Claim> claims, int second)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddSeconds(second),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
