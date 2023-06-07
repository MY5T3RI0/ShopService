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
    [Authorize]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly IMapper _mapper;
        public CategoryController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of categories
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /category
        /// </remarks>
        /// <returns>CategoryListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<ActionResult<CategoryListVm>> GetAllCategory()
        {
            var query = new GetCategoryListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the category by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /category/1
        /// </remarks>
        /// <param name="id">Id of the category</param>
        /// <returns>CategoryDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailsVm>> GetCategory(int id)
        {
            var query = new GetCategoryDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of categories with name like searchstring
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /category/like/di
        /// </remarks>
        /// <param name="searchString">Part of category's name (string)</param>
        /// <returns>CategoryLikeVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<CategoryLikeVm>> GetCategoryLike(string searchString)
        {
            var query = new GetCategoryLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the category
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /category
        /// {
        ///     Name: "category name"
        /// }
        /// </remarks>
        /// <param name="createCategoryDto">CreateCategoryDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        public async Task<ActionResult<int>> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto is null)
            {
                throw new ArgumentNullException(nameof(createCategoryDto));
            }

            var command = _mapper.Map<CreateCategoryCommand>(createCategoryDto);
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /category
        /// {
        ///     Name: "category name"
        /// }
        /// </remarks>
        /// <param name="updateCategoryDto">UpdateCategoryDto object</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (updateCategoryDto is null)
            {
                throw new ArgumentNullException(nameof(updateCategoryDto));
            }

            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the category by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /category/id
        /// </remarks>
        /// <param name="id">Id of the category</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
