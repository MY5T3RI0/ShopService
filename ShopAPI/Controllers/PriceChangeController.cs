using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeLike;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeList;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeRelated;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeRelatedList;

namespace ShopAPI.Controllers
{
    [ApiVersionNeutral]
    [Authorize]
    [Route("api/{version:apiVersion}/[controller]")]
    public class PriceChangeController : BaseController
    {
        private readonly IMapper _mapper;
        public PriceChangeController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of priceChanges
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /priceChange
        /// </remarks>
        /// <returns>Returns PriceChangeListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        public async Task<ActionResult<PriceChangeListVm>> GetAllPriceChange()
        {
            var query = new GetPriceChangeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the related list of priceChanges
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /priceChange/related
        /// </remarks>
        /// <returns>Returns PriceChangeRelatedListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Related")]
        public async Task<ActionResult<PriceChangeRelatedListVm>> GetAllRelatedPriceChange()
        {
            var query = new GetPriceChangeRelatedListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the related priceChange by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /priceChange/related/id
        /// </remarks>
        /// <param name="id">priceChange id</param>
        /// <returns>Returns PriceChangeRelatedDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Related/{id}")]
        public async Task<ActionResult<PriceChangeRelatedDetailsVm>> GetRelatedPriceChange(int id)
        {
            var query = new GetPriceChangeRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the priceChange by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /priceChange/id
        /// </remarks>
        /// <param name="id">priceChange id</param>
        /// <returns>Returns PriceChangeDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceChangeDetailsVm>> GetPriceChange(int id)
        {
            var query = new GetPriceChangeDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of priceChanges with name like searchstring
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /priceChange/like/23
        /// </remarks>
        /// <param name="searchString">Part of priceChange's date (string)</param>
        /// <returns>PriceChangeLikeVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<PriceChangeLikeVm>> GetPriceChangeLike(string searchString)
        {
            var query = new GetPriceChangeLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the priceChange
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /priceChange
        /// {
        ///     "changeDetailsDto": [
        ///         {
        ///             "productId": 1,
        ///             "newPrice": 10
        ///         }
        ///     ]
        /// }
        /// </remarks>
        /// <param name="createPriceChangeDto">CreatePriceChangeDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        public async Task<ActionResult<int>> CreatePriceChange([FromBody] CreatePriceChangeDto createPriceChangeDto)
        {
            if (createPriceChangeDto is null)
            {
                throw new ArgumentNullException(nameof(createPriceChangeDto));
            }

            var command = _mapper.Map<CreatePriceChangeCommand>(createPriceChangeDto);
            var entityId = await Mediator.Send(command);
            
            UpdateProductPriceCommand productCommand;
            foreach (var changeDetails in command.ChangeDetails)
            {
                productCommand = new UpdateProductPriceCommand { Id = changeDetails.ProductId };
                await Mediator.Send(productCommand);
            }

            return Ok(entityId);
        }

        /// <summary>
        /// Updates the priceChange by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /priceChange
        /// {
        ///     "id": 1,
        ///     "date": "2023-06-04",
        ///     "changeDetailsDto": [
        ///         {
        ///             "productId": 1,
        ///             "newPrice": 10
        ///         }
        ///     ]
        /// }
        /// </remarks>
        /// /// <param name="updatePriceChangeDto">UpdatePriceChangeDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        public async Task<IActionResult> UpdatePriceChange([FromBody] UpdatePriceChangeDto updatePriceChangeDto)
        {
            if (updatePriceChangeDto is null)
            {
                throw new ArgumentNullException(nameof(updatePriceChangeDto));
            }

            var command = _mapper.Map<UpdatePriceChangeCommand>(updatePriceChangeDto);
            await Mediator.Send(command);

            UpdateProductPriceCommand productCommand;
            foreach (var changeDetails in command.ChangesDetails)
            {
                productCommand = new UpdateProductPriceCommand { Id = changeDetails.ProductId };
                await Mediator.Send(productCommand);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes the priceChange by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /priceChange/id
        /// </remarks>
        /// /// <param name="id">Id of the priceChange</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriceChange(int id)
        {
            var command = new DeletePriceChangeCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
