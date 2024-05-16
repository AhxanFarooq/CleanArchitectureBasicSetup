using Application.Services.AreaServices.Command.AddContactCommand;
using Application.Services.AreaServices.Command.DeleteContactCommand;
using Application.Services.AreaServices.Command.GetAllContactQuery;
using Application.Services.AreaServices.Command.GetContactQuery;
using Application.Services.AreaServices.Command.UpdateContactCommand;
using Application.Services.IndustryServices.Command.AddIndustryCommand;
using Application.Services.IndustryServices.Command.DeleteIndustryCommand;
using Application.Services.IndustryServices.Command.GetAllIndustryQuery;
using Application.Services.IndustryServices.Command.UpdateIndustryCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ContactController>
        [Route("GetAll")]
        [HttpGet]

        public async Task<ActionResult<List<GetAllContactResponse>>> GetAll(
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllContactRequest(), cancellationToken);
            return response;
        }

        /// <summary>
        /// Get an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item to fetch record.</param>
        /// <returns>A response indicating success or failure.</returns>
        [Route("GetById")]
        [HttpGet]

        public async Task<ActionResult<GetContactResponse>> Get(Guid id,
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetContactRequest() { Id = id }, cancellationToken);
            if (response is null)
                return NotFound();
            return response;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<AddContactResponse>> Post([FromBody] AddContactRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // PUT api/<ContactController>/5
        [Route("Update")]
        [HttpPost]
        public async Task<ActionResult<UpdateContactResponse>> UpdateIndustry(UpdateContactRequest request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

        // DELETE api/<ContactController>/5
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
            await _mediator.Send(new DeleteContactRequest { Id = id }, cancellationToken);
            return NoContent();
        }
    }
}
