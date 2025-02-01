using Application.Services.Authentication.Command.RegisterCommand;
using Application.Services.Authentication.Queries.LoginQuery;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using NowApi.ViewModel.Authentication;

namespace NowApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, ILogger<AuthenticationController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginVm loginModel)
        {
            var loinRequest = _mapper.Map<LoginQueryRequest>(loginModel);

            var response = await _mediator.Send(loinRequest);

            return response.Match(
                login => Ok(response.Value),
                error => Problem(error)
            );
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationVm register)
        {
            var registerRequest = _mapper.Map<RegisterCommandRequest>(register);

            var response = await _mediator.Send(registerRequest);


            return response.Match(
                register => Created(),
                error => Problem(error)
            );

        }
    }
}
