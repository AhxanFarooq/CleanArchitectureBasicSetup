using Application.Services.Authentication.Command.PatientCommand;
using Application.Services.Authentication.Queries.LoginQuery;
using Application.Services.Patient.Query.GetPatientByIdQuery;
using Application.Services.Patient.Query.GetPatientListQuery;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowApi.ViewModel.Authentication;
using NowApi.ViewModel.Patient;

namespace NowApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles ="Admin")]
    public class PatientController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PatientController> _logger;
        private readonly IMapper _mapper;

        public PatientController(IMediator mediator, ILogger<PatientController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UpsertPatientRequest patient)
        {
            var request = _mapper.Map<PatientCommandRequest>(patient);

            var response = await _mediator.Send(request);

            return response.Match(
                login => Ok(response.Value),
                error => Problem(error)
            );
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllPatient([FromBody] GetAllPatient patient)
        {
            var request = _mapper.Map<GetPatientListQueryRequest>(patient);

            var response = await _mediator.Send(request);

            return response.Match(
                login => Ok(response.Value),
                error => Problem(error)
            );
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = new GetPatientByIdQueryRequest()
            {
                Id = id
            };

            var response = await _mediator.Send(request);

            return response.Match(
                login => Ok(response.Value),
                error => Problem(error)
            );
        }
    }
}
