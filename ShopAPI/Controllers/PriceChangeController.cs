﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeLike;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeList;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeRelated;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeRelatedList;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    public class PriceChangeController : BaseController
    {
        private readonly IMapper _mapper;
        public PriceChangeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PriceChangeListVm>> GetAll()
        {
            var query = new GetPriceChangeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Related")]
        public async Task<ActionResult<PriceChangeRelatedListVm>> GetAllRelated()
        {
            var query = new GetPriceChangeRelatedListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Related/{id}")]
        public async Task<ActionResult<PriceChangeRelatedDetailsVm>> GetAllRelated(int id)
        {
            var query = new GetPriceChangeRelatedDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriceChangeDetailsVm>> Get(int id)
        {
            var query = new GetPriceChangeDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Like/{searchString}")]
        public async Task<ActionResult<PriceChangeLikeVm>> Get(string searchString)
        {
            var query = new GetPriceChangeLikeQuery
            {
                SearchString = searchString
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePriceChangeDto createPriceChangeDto)
        {
            if (createPriceChangeDto is null)
            {
                throw new ArgumentNullException(nameof(createPriceChangeDto));
            }

            var command = _mapper.Map<CreatePriceChangeCommand>(createPriceChangeDto);
            var entityId = await Mediator.Send(command);
            
            UpdateProductPriceCommand productCommand;
            foreach (var changeDetails in command.ChangeDetails)
            {
                productCommand = new UpdateProductPriceCommand { Id = changeDetails.ProductId };
                await Mediator.Send(productCommand);
            }

            return Ok(entityId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePriceChangeDto updatePriceChangeDto)
        {
            if (updatePriceChangeDto is null)
            {
                throw new ArgumentNullException(nameof(updatePriceChangeDto));
            }

            var command = _mapper.Map<UpdatePriceChangeCommand>(updatePriceChangeDto);
            await Mediator.Send(command);

            UpdateProductPriceCommand productCommand;
            foreach (var changeDetails in command.ChangesDetails)
            {
                productCommand = new UpdateProductPriceCommand { Id = changeDetails.ProductId };
                await Mediator.Send(productCommand);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePriceChangeCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}