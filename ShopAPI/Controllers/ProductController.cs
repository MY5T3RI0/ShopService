using AutoMapper;
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
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ProductListVm>> GetAll()
        {
            var query = new GetProductListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Related")]
        public async Task<ActionResult<ProductRelatedListVm>> GetAllRelated()
        {
            var query = new GetProductRelatedListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Related/{id}")]
        public async Task<ActionResult<ProductRelatedDetailsVm>> GetAllRelated(int id)
        {
            var query = new GetProductRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsVm>> Get(int id)
        {
            var query = new GetProductDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<ProductLikeVm>> Get(string searchString)
        {
            var query = new GetProductLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductDto createProductDto)
        {
            if (createProductDto is null)
            {
                throw new ArgumentNullException(nameof(createProductDto));
            }

            var command = _mapper.Map<CreateProductCommand>(createProductDto);
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
        {
            if (updateProductDto is null)
            {
                throw new ArgumentNullException(nameof(updateProductDto));
            }

            var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
            await Mediator.Send(command);
            return NoContent();
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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
