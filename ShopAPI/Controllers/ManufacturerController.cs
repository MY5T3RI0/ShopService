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
    public class ManufacturerController : BaseController
    {
        private readonly IMapper _mapper;
        public ManufacturerController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ManufacturerListVm>> GetAll()
        {
            var query = new GetManufacturerListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerDetailsVm>> Get(int id)
        {
            var query = new GetManufacturerDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<ManufacturerLikeVm>> Get(string searchString)
        {
            var query = new GetManufacturerLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateManufacturerDto createManufacturerDto)
        {
            if (createManufacturerDto is null)
            {
                throw new ArgumentNullException(nameof(createManufacturerDto));
            }

            var command = _mapper.Map<CreateManufacturerCommand>(createManufacturerDto);
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateManufacturerDto updateManufacturerDto)
        {
            if (updateManufacturerDto is null)
            {
                throw new ArgumentNullException(nameof(updateManufacturerDto));
            }

            var command = _mapper.Map<UpdateManufacturerCommand>(updateManufacturerDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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
