using Application.ProductServices.ProductServices.UpdateProductCommand;
using Application.Services.AreaServices.Command.AddAreaCommand;
using Application.Services.AreaServices.Command.DeleteAreaCommand;
using Application.Services.AreaServices.Command.GetAllAreaQuery;
using Application.Services.AreaServices.Command.GetAreaQuery;
using Application.Services.AreaServices.Command.UpdateAreaCommand;
using Application.Services.Common;
using Application.Services.IndustryServices.Command.AddIndustryCommand;
using Application.Services.IndustryServices.Command.DeleteIndustryCommand;
using Application.Services.IndustryServices.Command.GetAllIndustryQuery;
using Application.Services.IndustryServices.Command.GetIndustryQuery;
using Application.Services.IndustryServices.Command.UpdateIndustryCommand;
using Application.Services.ProductServices.Command.AddProductCommand;
using Application.Services.ProductServices.Command.DeleteProductCommand;
using Application.Services.ProductServices.Command.GetAllProductQuery;
using Application.Services.ProductServices.Command.GetProductQuery;
using Application.Services.ProductServices.Command.UpdateProductCommand;
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
        /// <summary>
        /// Search area by its name.
        /// </summary>
        /// <param name="id">The name of the item to fetch record.</param>
        /// <param name="id">The name of the item to fetch record.</param>
        /// <returns>A response indicating success or failure.</returns>
        public async Task<ActionResult<PaginatedResponse<GetAllAreaResponse>>> GetAllArea(
           CancellationToken cancellationToken, int pageIndex = 1, int totalPages = 10)
        {
            var response = await _mediator.Send(new GetAllAreaRequest() { PageIndex = pageIndex, TotalSize = totalPages }, cancellationToken);
            return response;
        }

        [Route("Area/Search")]
        [HttpGet]
        /// <summary>
        /// Search area by its name.
        /// </summary>
        /// <param name="id">The name of the item to fetch record.</param>
        /// <returns>A response indicating success or failure.</returns>
        public async Task<ActionResult<PaginatedResponse<GetAllAreaResponse>>> SearchArea(string search,
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllAreaRequest() { Search = search}, cancellationToken);
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

        public async Task<ActionResult<PaginatedResponse<GetAllIndustryResponse>>> IndustryGetAll(
           CancellationToken cancellationToken, int pageIndex = 1, int totalPages = 10)
        {
            var response = await _mediator.Send(new GetAllIndustryRequest() { PageIndex = pageIndex, TotalPages = totalPages }, cancellationToken);
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
        [Route("Industry/Search")]
        [HttpGet]
        /// <summary>
        /// Search industry by its name.
        /// </summary>
        /// <param name="id">The name of the item to fetch record.</param>
        /// <returns>A response indicating success or failure.</returns>
        public async Task<ActionResult<PaginatedResponse<GetAllIndustryResponse>>> SearchIndustry(string search,
           CancellationToken cancellationToken, int pageIndex = 1, int totalPages = 10)
        {
            var response = await _mediator.Send(new GetAllIndustryRequest() { Search = search, PageIndex = pageIndex, TotalPages = totalPages }, cancellationToken);
            return response;
        }
        #endregion

        #region Product
        [Route("Product/Create")]
        [HttpPost]

        public async Task<ActionResult<AddProductResponse>> CreateProduct(AddProductRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [Route("Product/Update")]
        [HttpPost]

        public async Task<ActionResult<UpdateProductResponse>> UpdateProduct(UpdateProductRequest request,
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
        [Route("Product/Delete")]
        [HttpDelete]

        public async Task<ActionResult> DeleteProduct(Guid id,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteProductRequest { Id = id }, cancellationToken);
            return NoContent();
        }

        [Route("Product/GetAll")]
        [HttpGet]
        /// <summary>
        /// Search product by its name.
        /// </summary>
        /// <param name="id">The name of the item to fetch record.</param>
        /// <param name="id">The name of the item to fetch record.</param>
        /// <returns>A response indicating success or failure.</returns>
        public async Task<ActionResult<PaginatedResponse<GetAllProductResponse>>> GetAllProduct(
           CancellationToken cancellationToken, int pageIndex = 1, int totalPages = 10)
        {
            var response = await _mediator.Send(new GetAllProductRequest() { PageIndex = pageIndex, TotalSize = totalPages }, cancellationToken);
            return response;
        }

        [Route("Product/Search")]
        [HttpGet]
        /// <summary>
        /// Search product by its name.
        /// </summary>
        /// <param name="search">The name of the item to fetch record.</param>
        /// <param name="pageIndex">Provide page index.</param>
        /// <param name="totalPages">Provide total number of pages.</param>
        /// <returns>A response indicating success or failure.</returns>
        public async Task<ActionResult<PaginatedResponse<GetAllProductResponse>>> SearchProduct(CancellationToken cancellationToken, string search, int pageIndex = 1, int totalPages = 10)
        {
            var response = await _mediator.Send(new GetAllProductRequest() { Search = search, PageIndex = pageIndex, TotalSize = totalPages }, cancellationToken);
            return response;
        }

        /// <summary>
        /// Get an item by its ID.
        /// </summary>
        /// <param name="id">The ID of the item to fetch record.</param>
        /// <returns>A response indicating success or failure.</returns>
        [Route("Product/GetById")]
        [HttpGet]

        public async Task<ActionResult<GetProductResponse>> GetProductById(Guid id,
           CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetProductRequest() { Id = id }, cancellationToken);
            if (response is null)
                return NotFound();
            return response;
        }
        #endregion
    }
}
