using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [ApiVersionNeutral]
    [Authorize]
    [Route("api/{version:apiVersion}/[controller]")]
    public class DeliveryController : BaseController
    {
        private readonly IMapper _mapper;
        public DeliveryController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of deliveries
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /delivery
        /// </remarks>
        /// <returns>Returns DeliveryListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        public async Task<ActionResult<DeliveryListVm>> GetAllDelivery()
        {
            var query = new GetDeliveriesListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the related list of deliveries
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /delivery/related
        /// </remarks>
        /// <returns>Returns DeliveryRelatedListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Related")]
        public async Task<ActionResult<DeliveryRelatedListVm>> GetAllRelatedDelivery()
        {
            var query = new GetDeliveryRelatedListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the related delivery by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /delivery/related/id
        /// </remarks>
        /// <param name="id">delivery id</param>
        /// <returns>Returns DeliveryRelatedDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Related/{id}")]
        public async Task<ActionResult<DeliveryRelatedDetailsVm>> GetRelatedDelivery(int id)
        {
            var query = new GetDeliveryRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the delivery by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /delivery/id
        /// </remarks>
        /// <param name="id">delivery id</param>
        /// <returns>Returns DeliveryDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDetailsVm>> GetDelivery(int id)
        {
            var query = new GetDeliveryDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of deliveries with name like searchstring
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /delivery/like/di
        /// </remarks>
        /// <param name="searchString">Part of delivery's date (string)</param>
        /// <returns>DeliveryLikeVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<DeliveryLikeVm>> GetDeliveryLike(string searchString)
        {
            var query = new GetDeliveryLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the delivery
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /delivery
        /// {
        ///     "storeId": 1,
        ///     "deliveryInfoDto": [
        ///         {
        ///             "productId": 1,
        ///             "productCount": 10
        ///         }
        ///     ]
        /// }
        /// </remarks>
        /// <param name="createDeliveryDto">CreateDeliveryDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        public async Task<ActionResult<int>> CreateDelivery([FromBody] CreateDeliveryDto createDeliveryDto)
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

        /// <summary>
        /// Deletes the delivery by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /delivery/id
        /// </remarks>
        /// /// <param name="id">Id of the delivery</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
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
