using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreDetails;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreLike;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreList;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreRelated;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreRelatedList;

namespace ShopAPI.Controllers
{
    [ApiVersionNeutral]
    [Authorize]
    [Route("api/{version:apiVersion}/[controller]")]
    public class StoreController : BaseController
    {
        private readonly IMapper _mapper;
        public StoreController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of stores
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /store
        /// </remarks>
        /// <returns>Returns StoreListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        public async Task<ActionResult<StoreListVm>> GetAllStore()
        {
            var query = new GetStoreListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the related list of stores
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /store/related
        /// </remarks>
        /// <returns>Returns StoreRelatedListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Related")]
        public async Task<ActionResult<StoreRelatedListVm>> GetAllRelatedStore()
        {
            var query = new GetStoreRelatedListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the related store by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /store/related/id
        /// </remarks>
        /// <param name="id">store id</param>
        /// <returns>Returns StoreRelatedDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Related/{id}")]
        public async Task<ActionResult<StoreRelatedDetailsVm>> GetRelatedStore(int id)
        {
            var query = new GetStoreRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the store by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /store/id
        /// </remarks>
        /// <param name="id">store id</param>
        /// <returns>Returns StoreDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDetailsVm>> GetStore(int id)
        {
            var query = new GetStoreDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of stores with name like searchstring
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /store/like/di
        /// </remarks>
        /// <param name="searchString">Part of store's name (string)</param>
        /// <returns>StoreLikeVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<StoreLikeVm>> GetStoreLike(string searchString)
        {
            var query = new GetStoreLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the store
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /store
        /// {
        ///     "name": "store name"
        /// }
        /// </remarks>
        /// <param name="createStoreDto">CreateStoreDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        public async Task<ActionResult<int>> CreateStore([FromBody] CreateStoreDto createStoreDto)
        {
            if (createStoreDto is null)
            {
                throw new ArgumentNullException(nameof(createStoreDto));
            }

            var command = _mapper.Map<CreateStoreCommand>(createStoreDto);
            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }

        /// <summary>
        /// Updates the store by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /store
        /// {
        ///     "id": 1,
        ///     "name": "store name",
        /// }
        /// </remarks>
        /// <param name="updateStoreDto">UpdateStoreDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        public async Task<IActionResult> UpdateStore([FromBody] UpdateStoreDto updateStoreDto)
        {
            if (updateStoreDto is null)
            {
                throw new ArgumentNullException(nameof(updateStoreDto));
            }

            var command = _mapper.Map<UpdateStoreCommand>(updateStoreDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the store by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /store/id
        /// </remarks>
        /// <param name="id">Id of the store</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var command = new DeleteStoreCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
