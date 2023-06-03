using AutoMapper;
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
    [Route("api/[controller]")]
    public class StoreController : BaseController
    {
        private readonly IMapper _mapper;
        public StoreController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<StoreListVm>> GetAll()
        {
            var query = new GetStoreListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Related")]
        public async Task<ActionResult<StoreRelatedListVm>> GetAllRelated()
        {
            var query = new GetStoreRelatedListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Related/{id}")]
        public async Task<ActionResult<StoreRelatedDetailsVm>> GetAllRelated(int id)
        {
            var query = new GetStoreRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDetailsVm>> Get(int id)
        {
            var query = new GetStoreDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<StoreLikeVm>> Get(string searchString)
        {
            var query = new GetStoreLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateStoreDto createStoreDto)
        {
            if (createStoreDto is null)
            {
                throw new ArgumentNullException(nameof(createStoreDto));
            }

            var command = _mapper.Map<CreateStoreCommand>(createStoreDto);
            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStoreDto updateStoreDto)
        {
            if (updateStoreDto is null)
            {
                throw new ArgumentNullException(nameof(updateStoreDto));
            }

            var command = _mapper.Map<UpdateStoreCommand>(updateStoreDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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
