using AutoMapper;
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
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly IMapper _mapper;
        public CategoryController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<CategoryListVm>> GetAll()
        {
            var query = new GetCategoryListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailsVm>> Get(int id)
        {
            var query = new GetCategoryDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<CategoryLikeVm>> Get(string searchString)
        {
            var query = new GetCategoryLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto is null)
            {
                throw new ArgumentNullException(nameof(createCategoryDto));
            }

            var command = _mapper.Map<CreateCategoryCommand>(createCategoryDto);
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (updateCategoryDto is null)
            {
                throw new ArgumentNullException(nameof(updateCategoryDto));
            }

            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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
