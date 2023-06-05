using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [ApiVersionNeutral]
    [Authorize]
    [Route("api/{version:apiVersion}/[controller]")]
    public class PurchaseController : BaseController
    {
        private readonly IMapper _mapper;
        public PurchaseController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of purchases
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /purchase
        /// </remarks>
        /// <returns>Returns PurchaseListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        public async Task<ActionResult<PurchaseListVm>> GetAll()
        {
            var query = new GetPurchaseListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the related list of purchases
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /purchase/related
        /// </remarks>
        /// <returns>Returns PurchaseRelatedListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Related")]
        public async Task<ActionResult<PurchaseRelatedListVm>> GetAllRelated()
        {
            var query = new GetPurchaseRelatedListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the related purchase by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /purchase/related/id
        /// </remarks>
        /// <param name="id">purchase id</param>
        /// <returns>Returns PurchaseRelatedDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
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

        /// <summary>
        /// Gets the purchase by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /purchase/id
        /// </remarks>
        /// <param name="id">purchase id</param>
        /// <returns>Returns PurchaseDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
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

        /// <summary>
        /// Gets the list of purchases with name like searchstring
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /purchase/like/23
        /// </remarks>
        /// <param name="searchString">Part of purchase's date (string)</param>
        /// <returns>PurchaseLikeVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
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

        /// <summary>
        /// Creates the purchase
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /purchase
        /// {
        ///   "customerId": 1,
        ///   "storeProducts": [
        ///     {
        ///       "storeId": 1,
        ///       "purchaseDetails": [
        ///         {
        ///           "productId": 1,
        ///           "productCount": 10,
        ///           "discount": 5
        ///         }
        ///       ]
        ///     }
        ///   ]
        /// }
        /// </remarks>
        /// <param name="createPurchaseDto">CreatePurchaseDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
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

        /// <summary>
        /// Deletes the purchase by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /purchase/id
        /// </remarks>
        /// /// <param name="id">Id of the purchase</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
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
