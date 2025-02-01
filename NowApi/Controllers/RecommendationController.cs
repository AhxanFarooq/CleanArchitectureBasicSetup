using Application.Services.Authentication.Command.PatientCommand;
using Application.Services.Authentication.Command.RecommendationCommand;
using Application.Services.Patient.Query.GetPatientByIdQuery;
using Application.Services.Patient.Query.GetPatientListQuery;
using Application.Services.Recommendation.Query.GetRecommendationByIdQuery;
using Application.Services.Recommendation.Query.GetRecommendationListQuery;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowApi.ViewModel.Patient;
using NowApi.ViewModel.Recommendation;

namespace NowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RecommendationController> _logger;
        private readonly IMapper _mapper;

        public RecommendationController(IMediator mediator, ILogger<RecommendationController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UpsertRecommendation recommendation)
        {
            var request = _mapper.Map<RecommendationCommandRequest>(recommendation);

            var response = await _mediator.Send(request);

            return response.Match(
                login => Ok(response.Value),
                error => Problem(error)
            );
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] GetAllRecommendation recommendation)
        {
            var request = _mapper.Map< GetRecommendationListQueryRequest >(recommendation);

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
            var request = new GetRecommendationByIdQueryRequest()
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
