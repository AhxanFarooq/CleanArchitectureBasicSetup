using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.UserServices.Command.UpdateUser;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.Queries.SignInUser
{
    public class SignInUserHandler : IRequestHandler<SignInUserRequest, SignInUserResponse>
    {
        protected readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        public SignInUserHandler(IUserRepository userRepository, IMediator mediator) { 
            _userRepository = userRepository;
            _mediator = mediator;
        }
        public async Task<SignInUserResponse> Handle(SignInUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.UserName, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            //Decode base64 string to string

            byte[] bytes = Convert.FromBase64String(user.Password);

            // Convert byte array to string
            string decodedString = Encoding.UTF8.GetString(bytes);

            if (request.Password.Equals(decodedString, StringComparison.OrdinalIgnoreCase))
            {
                decimal? balance = user.Balance;
                if(!user.IsOldUser) { balance = 5; }
                await _mediator.Send(new UpdateUserRequest(user.Id,user.FirstName, user.LastName,request.Device, request.IpAddress, request.Browser, balance), cancellationToken);
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("SOME_RANDOM_KEY_DO_NOT_SHARE_JUST_DEMO"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: null,  // Optionally include issuer
                    audience: null,  // Optionally include audience
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return new SignInUserResponse
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = jwt,
                };
            }
            else
                return new SignInUserResponse
                {
                    Message = "User Credential is not valid"
                };

        }
    }
}
