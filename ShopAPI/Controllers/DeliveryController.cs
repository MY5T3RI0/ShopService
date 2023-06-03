using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopDAL.Models;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    public class DeliveryController : BaseController
    {
        private readonly IMapper _mapper;
        public DeliveryController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<DeliveryListVm>> GetAll()
        {
            var query = new GetDeliveriesListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Related")]
        public async Task<ActionResult<DeliveryRelatedListVm>> GetAllRelated()
        {
            var query = new GetDeliveryRelatedListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Related/{id}")]
        public async Task<ActionResult<DeliveryRelatedDetailsVm>> GetAllRelated(int id)
        {
            var query = new GetDeliveryRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDetailsVm>> Get(int id)
        {
            var query = new GetDeliveryDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<DeliveryLikeVm>> Get(string searchString)
        {
            var query = new GetDeliveryLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateDeliveryDto createDeliveryDto)
        {
            if (createDeliveryDto is null)
            {
                throw new ArgumentNullException(nameof(createDeliveryDto));
            }

            var command = _mapper.Map<CreateDeliveryCommand>(createDeliveryDto);

            var storeCommand = new UpdateProductsInStoreCommand
            {
                Id = command.StoreId,
                ProductsToChange = command.DeliveryInfos.Select(x => (x.ProductId, x.ProductCount))
            };

            await Mediator.Send(storeCommand);
            var deliveryId = await Mediator.Send(command);

            return Ok(deliveryId);
        }

        //does not work correctly due to links
        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateDeliveryDto updateDeliveryDto)
        //{
        //    if (updateDeliveryDto is null)
        //    {
        //        throw new ArgumentNullException(nameof(updateDeliveryDto));
        //    }

        //    var command = _mapper.Map<UpdateDeliveryCommand>(updateDeliveryDto);

        //    var query = new GetDeliveryRelatedDetailsQuery
        //    {
        //        Id = command.Id
        //    };
        //    var vm = await Mediator.Send(query);

        //    await Mediator.Send(command);

        //    var deliveryNew = command.DeliveryInfos.Select(x => (x.ProductId, x.ProductCount));
        //    var deliveryOld = vm.DeliveryInfos.Select(x => (x.ProductId, x.ProductCount));

        //    if (command.StoreId == vm.Store.Id)
        //    {
        //        var deliveryDifference = deliveryNew.Zip(deliveryOld, (x, y) => (x.ProductId, x.ProductCount - y.ProductCount));

        //        var storeCommand = new UpdateProductsInStoreCommand
        //        {
        //            Id = command.StoreId,
        //            ProductsToChange = deliveryDifference
        //        };

        //        await Mediator.Send(storeCommand);
        //    }
        //    else
        //    {
        //        var storeCommand = new UpdateProductsInStoreCommand
        //        {
        //            Id = vm.Store.Id,
        //            ProductsToChange = deliveryOld.Select(x => (x.ProductId, -x.ProductCount))
        //        };
        //        await Mediator.Send(storeCommand);
        //        storeCommand = new UpdateProductsInStoreCommand
        //        {
        //            Id = command.StoreId,
        //            ProductsToChange = deliveryNew
        //        };
        //        await Mediator.Send(storeCommand);
        //    }

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDeliveryCommand
            {
                Id = id,
            };

            var query = new GetDeliveryRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            var storeCommand = new UpdateProductsInStoreCommand
            {
                Id = vm.Store.Id,
                ProductsToChange = vm.DeliveryInfos.Select(x => (x.ProductId, x.ProductCount))
            };

            await Mediator.Send(storeCommand);

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
