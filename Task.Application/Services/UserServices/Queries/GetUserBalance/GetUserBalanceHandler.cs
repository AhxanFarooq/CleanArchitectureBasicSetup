using Application.Common.Exceptions;
using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.Queries.GetUserBalance
{
    public class GetUserBalanceHandler : IRequestHandler<GetUserBalanceRequest, GetUserBalanceResponse>
    {
        protected readonly IUserRepository _userRepository;
        public GetUserBalanceHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetUserBalanceResponse> Handle(GetUserBalanceRequest request, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(request.token) as JwtSecurityToken;

            if (jwtToken == null)
                throw new NotFoundException("Token nt passed");

            // Assuming the user ID is stored in the "sub" claim
            var userId = jwtToken.Claims.First(claim => claim.Type == "sub").Value;

            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId), cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return new GetUserBalanceResponse()
            {
                Balance = user.Balance,
            };
        }
    }
}
