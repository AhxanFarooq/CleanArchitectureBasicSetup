using Application.Services.UserServices.Command.CreateUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Application.Services.UserServices.Queries.SignInUser;
using Application.Services.UserServices.Queries.GetUserBalance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        public UserController(UserManager<IdentityUser> userManager, 
            IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _userManager = userManager;
            _configuration = configuration;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
        //{
        //    var response = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
        //    return Ok(response);
        //}
        [Route("SignUp")]
        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> SignUp(CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            var user = new IdentityUser { UserName = request.UserName, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return Ok(new { result = "User created successfully!" });
            }

            return BadRequest(result.Errors);
        }

        [Route("authenticate")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<SignInUserResponse>> SignIn(SignInUserRequest request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                var parts = tokenString.Split('.');
                Console.WriteLine($"Header: {parts[0]}");
                Console.WriteLine($"Payload: {parts[1]}");
                Console.WriteLine($"Signature: {parts[2]}");

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        [Route("auth/balance")]
        [HttpPost]
        
        public async Task<ActionResult<GetUserBalanceResponse>> GetBalance(GetUserBalanceRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
