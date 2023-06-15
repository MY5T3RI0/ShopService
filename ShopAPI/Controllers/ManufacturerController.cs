using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList;

namespace ShopAPI.Controllers
{
    [ApiVersionNeutral]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ManufacturerController : BaseController
    {
        private readonly IMapper _mapper;
        public ManufacturerController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of manufacturers
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /manufacturer
        /// </remarks>
        /// <returns>Returns ManufacturerListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        public async Task<ActionResult<ManufacturerListVm>> GetAllManufacturer()
        {
            var query = new GetManufacturerListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the manufacturer by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /manufacturer/id
        /// </remarks>
        /// <param name="id">manufacturer id</param>
        /// <returns>Returns ManufacturerDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerDetailsVm>> GetManufacturer(int id)
        {
            var query = new GetManufacturerDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of manufacturers with name like searchstring
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /manufacturer/like/di
        /// </remarks>
        /// <param name="searchString">Part of manufacturer's name (string)</param>
        /// <returns>ManufacturerLikeVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<ManufacturerLikeVm>> GetManufacturerLike(string searchString)
        {
            var query = new GetManufacturerLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the manufacturer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /manufacturer
        /// {
        ///     Name: "manufacturer name"
        /// }
        /// </remarks>
        /// <param name="createManufacturerDto">CreateManufacturerDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        public async Task<ActionResult<int>> CreateManufacturer([FromBody] CreateManufacturerDto createManufacturerDto)
        {
            if (createManufacturerDto is null)
            {
                throw new ArgumentNullException(nameof(createManufacturerDto));
            }

            var command = _mapper.Map<CreateManufacturerCommand>(createManufacturerDto);
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }

        /// <summary>
        /// Updates the manufacturer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /manufacturer
        /// {
        ///     Name: "manufacturer name"
        /// }
        /// </remarks>
        /// /// <param name="updateManufacturerDto">UpdateManufacturerDto object</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        public async Task<IActionResult> UpdateManufacturer([FromBody] UpdateManufacturerDto updateManufacturerDto)
        {
            if (updateManufacturerDto is null)
            {
                throw new ArgumentNullException(nameof(updateManufacturerDto));
            }

            var command = _mapper.Map<UpdateManufacturerCommand>(updateManufacturerDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the manufacturer by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /manufacturer/id
        /// </remarks>
        /// /// <param name="id">Id of the manufacturer</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            var command = new DeleteManufacturerCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
