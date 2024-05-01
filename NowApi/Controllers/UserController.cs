using Application.Services.UserServices.Command.CreateUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Application.Services.UserServices.Queries.SignInUser;
using Application.Services.UserServices.Queries.GetUserBalance;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace NowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
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
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [Route("authenticate")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<SignInUserResponse>> SignIn(SignInUserRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
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
