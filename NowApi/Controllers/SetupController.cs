using Application.Services.AreaServices.Command.AddAreaCommand;
using Application.Services.AreaServices.Command.DeleteAreaCommand;
using Application.Services.AreaServices.Command.GetAllAreaQuery;
using Application.Services.AreaServices.Command.GetAreaQuery;
using Application.Services.AreaServices.Command.UpdateAreaCommand;
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
        [Route("Update")]
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

        public async Task<ActionResult> Delete(Guid id,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAreaRequest { Id = id }, cancellationToken);
            return NoContent();
        }

        [Route("GetAll")]
        [HttpGet]

        public async Task<ActionResult<List<GetAllAreaResponse>>> GetAll(
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
        [Route("GetById")]
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
    }
}
