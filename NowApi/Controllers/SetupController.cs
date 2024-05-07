using Application.Services.AreaServices.Command.AddAreaCommand;
using Application.Services.AreaServices.Command.DeleteAreaCommand;
using Application.Services.AreaServices.Command.GetAllAreaQuery;
using Application.Services.AreaServices.Command.GetAreaQuery;
using Application.Services.AreaServices.Command.UpdateAreaCommand;
using Application.Services.IndustryServices.Command.AddIndustryCommand;
using Application.Services.IndustryServices.Command.DeleteIndustryCommand;
using Application.Services.IndustryServices.Command.GetAllIndustryQuery;
using Application.Services.IndustryServices.Command.GetIndustryQuery;
using Application.Services.IndustryServices.Command.UpdateIndustryCommand;
using Application.Services.UserServices.Queries.GetUserBalance;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SetupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Area
        [Route("Area/Create")]
        [HttpPost]

        public async Task<ActionResult<AddAreaResponse>> CreateArea(AddAreaRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [Route("Area/Update")]
        [HttpPost]

        public async Task<ActionResult<UpdateAreaResponse>> UpdateArea(UpdateAreaRequest request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Deletes an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <returns>A response indicating success or failure.</returns>
        [Route("Area/Delete")]
        [HttpDelete]

        public async Task<ActionResult> DeleteArea(Guid id,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAreaRequest { Id = id }, cancellationToken);
            return NoContent();
        }

        [Route("Area/GetAll")]
        [HttpGet]

        public async Task<ActionResult<List<GetAllAreaResponse>>> GetAllArea(
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllAreaRequest(), cancellationToken);
            return response;
        }

        /// <summary>
        /// Get an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item to fetch record.</param>
        /// <returns>A response indicating success or failure.</returns>
        [Route("Area/GetById")]
        [HttpGet]

        public async Task<ActionResult<GetAreaResponse>> GetAreaById(Guid id,
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAreaRequest() { Id = id }, cancellationToken);
            if (response is null)
                return NotFound();
            return response;
        }
        #endregion

        #region Industry
        [Route("Industry/Create")]
        [HttpPost]

        public async Task<ActionResult<AddIndustryResponse>> CreateIndustry(AddIndustryRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [Route("Industry/Update")]
        [HttpPost]

        public async Task<ActionResult<UpdateIndustryResponse>> UpdateIndustry(UpdateIndustryRequest request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Deletes an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <returns>A response indicating success or failure.</returns>
        [Route("Industry/Delete")]
        [HttpDelete]

        public async Task<ActionResult> DeleteIndustry(Guid id,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteIndustryRequest { Id = id }, cancellationToken);
            return NoContent();
        }

        [Route("Industry/GetAll")]
        [HttpGet]

        public async Task<ActionResult<List<GetAllIndustryResponse>>> IndustryGetAll(
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllIndustryRequest(), cancellationToken);
            return response;
        }

        /// <summary>
        /// Get an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item to fetch record.</param>
        /// <returns>A response indicating success or failure.</returns>
        [Route("Industry/GetById")]
        [HttpGet]

        public async Task<ActionResult<GetIndustryResponse>> GetIndustryById(Guid id,
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetIndustryRequest() { Id = id }, cancellationToken);
            if (response is null)
                return NotFound();
            return response;
        }
        #endregion
    }
}
