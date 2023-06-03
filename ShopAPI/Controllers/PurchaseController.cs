using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseLike;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseList;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseRelated;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseRelatedList;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    public class PurchaseController : BaseController
    {
        private readonly IMapper _mapper;
        public PurchaseController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PurchaseListVm>> GetAll()
        {
            var query = new GetPurchaseListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Related")]
        public async Task<ActionResult<PurchaseRelatedListVm>> GetAllRelated()
        {
            var query = new GetPurchaseRelatedListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Related/{id}")]
        public async Task<ActionResult<PurchaseRelatedDetailsVm>> GetAllRelated(int id)
        {
            var query = new GetPurchaseRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDetailsVm>> Get(int id)
        {
            var query = new GetPurchaseDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<PurchaseLikeVm>> Get(string searchString)
        {
            var query = new GetPurchaseLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePurchaseDto createPurchaseDto)
        {
            if (createPurchaseDto is null)
            {
                throw new ArgumentNullException(nameof(createPurchaseDto));
            }

            var command = _mapper.Map<CreatePurchaseCommand>(createPurchaseDto);

            foreach(var store in command.StoreProducts)
            {
                var storeCommand = new UpdateProductsInStoreCommand
                {
                    Id = store.StoreId,
                    ProductsToChange = store.PurchaseDetails.Select(x => (x.ProductId, -x.ProductCount))
                };

                await Mediator.Send(storeCommand);
            }

            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }

        //does not work correctly due to links
        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdatePurchaseDto updatePurchaseDto)
        //{
        //    if (updatePurchaseDto is null)
        //    {
        //        throw new ArgumentNullException(nameof(updatePurchaseDto));
        //    }

        //    var command = _mapper.Map<UpdatePurchaseCommand>(updatePurchaseDto);
        //    await Mediator.Send(command);
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePurchaseCommand
            {
                Id = id,
            };

            var query = new GetPurchaseRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            UpdateProductsInStoreCommand storeCommand;
            foreach (var store in vm.StoreProducts)
            {
                storeCommand = new UpdateProductsInStoreCommand
                {
                    Id = store.StoreId,
                    ProductsToChange = store.PurchaseDetails.Select(x => (x.ProductId, x.ProductCount))
                };

                await Mediator.Send(storeCommand);
            }

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
