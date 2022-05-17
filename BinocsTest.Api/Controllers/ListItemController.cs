using AutoMapper;
using BinocsTest.Api.IO.Requests;
using BinocsTest.Api.IO.Responses;
using BinocsTest.Core.Handlers.CommandHandlers.Commands;
using BinocsTest.Core.Handlers.RequestHandlers.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BinocsTest.Api.Controllers
{
    [Route("api/v1/List")]
    [ApiController]
    public class ListItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ListItemController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{listId}/ListItems")]
        public async Task<IActionResult> GetListItems([FromRoute] Guid listId)
        {
            var query = new GetListItemsRequest(listId);
            var coreResult = await _mediator.Send(query);

            var response = _mapper.Map<GetListItemsResponse>(coreResult);

            return Ok(response);
        }

        [HttpPost("{listId}/ListItem")]
        public async Task<IActionResult> Create([FromRoute] Guid listId, [FromBody] CreateListItemRequest request)
        {
            var command = new CreateListItemCommand(listId, request.Content);
            var result = await _mediator.Send(command);

            return StatusCode(201, new { Id = result, command.ListId, command.Content });
        }

        [HttpDelete("ListItem/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteListItemCommand(id);
            await _mediator.Send(command);
           
            return NoContent();
        }
    }
}