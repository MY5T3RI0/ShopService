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
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;
        public CustomerController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<CustomerListVm>> GetAll()
        {
            var query = new GetCustomerListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

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
