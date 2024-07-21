using Application.Services.AreaServices.Command.AddQuotationCommand;
using Application.Services.AreaServices.Command.DeleteQuotationCommand;
using Application.Services.AreaServices.Command.GetAllQuotationQuery;
using Application.Services.AreaServices.Command.GetQuotationQuery;
using Application.Services.AreaServices.Command.UpdateQuotationCommand;
using Application.Services.Common;
using Application.Services.QuotationServices.Queries.GetAutoCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuotationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<QuotationController>
        [Route("GetAll")]
        [HttpGet]

        public async Task<ActionResult<PaginatedResponse<GetAllQuotationResponse>>> GetAll(
           CancellationToken cancellationToken, int pageIndex = 1, int totalPages = 10)
        {
            var response = await _mediator.Send(new GetAllQuotationRequest() { PageIndex = pageIndex, TotalPages = totalPages }, cancellationToken);
            return response;
        }

        [Route("Search")]
        [HttpGet]
        /// <summary>
        /// Search industry by its name.
        /// </summary>
        /// <param name="id">The name of the item to fetch record.</param>
        /// <returns>A response indicating success or failure.</returns>
        public async Task<ActionResult<PaginatedResponse<GetAllQuotationResponse>>> Search(string search,
           CancellationToken cancellationToken, int pageIndex = 1, int totalPages = 10)
        {
            var response = await _mediator.Send(new GetAllQuotationRequest() { Search = search, PageIndex = pageIndex, TotalPages = totalPages }, cancellationToken);
            return response;
        }
        /// <summary>
        /// Get an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item to fetch record.</param>
        /// <returns>A response indicating success or failure.</returns>
        [Route("GetById")]
        [HttpGet]

        public async Task<ActionResult<GetQuotationResponse>> Get(Guid id,
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetQuotationRequest() { Id = id }, cancellationToken);
            if (response is null)
                return NotFound();
            return response;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<AddQuotationResponse>> Post([FromBody] AddQuotationRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // PUT api/<QuotationController>/5
        [Route("Update")]
        [HttpPost]
        public async Task<ActionResult<UpdateQuotationResponse>> UpdateIndustry(UpdateQuotationRequest request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        // DELETE api/<QuotationController>/5
        /// <summary>
        /// Deletes an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <returns>A response indicating success or failure.</returns>
        [Route("Delete")]
        [HttpDelete]

        public async Task<ActionResult> Delete(Guid id,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteQuotationRequest { Id = id }, cancellationToken);
            return NoContent();
        }

        [Route("GetAutoCode")]
        [HttpGet]

        public async Task<ActionResult<GetAutoCodeResponse>> GetAutoCode(
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAutoCodeRequest() , cancellationToken);
            if (response is null)
                return NotFound();
            return response;
        }
    }
}
