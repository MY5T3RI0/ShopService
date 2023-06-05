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
    [Route("api/{version:apiVersion}/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;
        public CustomerController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of customers
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /customer
        /// </remarks>
        /// <returns>Returns CustomerListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        public async Task<ActionResult<CustomerListVm>> GetAll()
        {
            var query = new GetCustomerListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the customer by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /customer/id
        /// </remarks>
        /// <param name="id">customer id</param>
        /// <returns>Returns CustomerDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetailsVm>> Get(int id)
        {
            var query = new GetCustomerDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of customers with name like searchstring
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /customer/like/di
        /// </remarks>
        /// <param name="searchString">Part of customer's name (string)</param>
        /// <returns>CustomerLikeVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<CustomerLikeVm>> Get(string searchString)
        {
            var query = new GetCustomerLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the customer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /customer
        /// {
        ///     Name: "customer name"
        /// }
        /// </remarks>
        /// <param name="createCustomerDto">CreateCustomerDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCustomerDto createCustomerDto)
        {
            if (createCustomerDto is null)
            {
                throw new ArgumentNullException(nameof(createCustomerDto));
            }

            var command = _mapper.Map<CreateCustomerCommand>(createCustomerDto);
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /customer
        /// {
        ///     Name: "customer name"
        /// }
        /// </remarks>
        /// /// <param name="updateCustomerDto">UpdateCustomerDto object</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDto updateCustomerDto)
        {
            if (updateCustomerDto is null)
            {
                throw new ArgumentNullException(nameof(updateCustomerDto));
            }

            var command = _mapper.Map<UpdateCustomerCommand>(updateCustomerDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the customer by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /customer/id
        /// </remarks>
        /// /// <param name="id">Id of the customer</param>
        /// <returns>Returns No Content</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
