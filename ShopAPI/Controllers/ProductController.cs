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
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelated;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList;

namespace ShopAPI.Controllers
{
    [ApiVersionNeutral]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of products
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /product
        /// </remarks>
        /// <returns>Returns ProductListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        public async Task<ActionResult<ProductListVm>> GetAllProduct()
        {
            var query = new GetProductListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the related list of products
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /product/related
        /// </remarks>
        /// <returns>Returns ProductRelatedListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Related")]
        public async Task<ActionResult<ProductRelatedListVm>> GetAllRelatedProduct()
        {
            var query = new GetProductRelatedListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the related product by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /product/related/id
        /// </remarks>
        /// <param name="id">product id</param>
        /// <returns>Returns ProductRelatedDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Related/{id}")]
        public async Task<ActionResult<ProductRelatedDetailsVm>> GetRelatedProduct(int id)
        {
            var query = new GetProductRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the product by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /product/id
        /// </remarks>
        /// <param name="id">product id</param>
        /// <returns>Returns ProductDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsVm>> GetProduct(int id)
        {
            var query = new GetProductDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of products with name like searchstring
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /product/like/di
        /// </remarks>
        /// <param name="searchString">Part of product's name (string)</param>
        /// <returns>ProductLikeVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<ProductLikeVm>> GetProductLike(string searchString)
        {
            var query = new GetProductLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the product
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /product
        /// {
        ///     "name": "product name",
        ///     "price": 10,
        ///     "categoryId": 1,
        ///     "manufacturerId": 1
        /// }
        /// </remarks>
        /// <param name="createProductDto">CreateProductDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            if (createProductDto is null)
            {
                throw new ArgumentNullException(nameof(createProductDto));
            }

            var command = _mapper.Map<CreateProductCommand>(createProductDto);
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }

        /// <summary>
        /// Updates the product by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /product
        /// {
        ///     "id": 1,
        ///     "name": "product name",
        ///     "price": 10
        /// }
        /// </remarks>
        /// <param name="updateProductDto">UpdateProductDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            if (updateProductDto is null)
            {
                throw new ArgumentNullException(nameof(updateProductDto));
            }

            var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
            await Mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Updates the productPrice by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /product/price/5
        /// </remarks>
        /// <param name="id">product id (int)object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut("Price")]
        public async Task<IActionResult> UpdatePrice(int id)
        {
            var command = new UpdateProductPriceCommand
            {
                Id = id,
            };

            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the product by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /product/id
        /// </remarks>
        /// <param name="id">Id of the product</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
