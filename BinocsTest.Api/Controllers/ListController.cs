using AutoMapper;
using BinocsTest.Api.IO.Requests;
using BinocsTest.Api.IO.Responses;
using BinocsTest.Core.Handlers.CommandHandlers.Commands;
using BinocsTest.Core.Handlers.RequestHandlers.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BinocsTest.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ListController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllListsRequest();
            var coreResult = await _mediator.Send(query);

            var response = _mapper.Map<GetAllListsResponse>(coreResult);


            return Ok(response);
        }
        [HttpGet("total")]
        public async Task<IActionResult> GetTotalCount()
        {
            var query = new GetTotalCountRequest();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        /// <summary>
        /// Creates a new list with provided name
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateListRequest request)
        {
            var command = new CreateListCommand(request.Name);
            var coreResult = await _mediator.Send(command);

            var response = _mapper.Map<CreateListResponse>(coreResult);
            return StatusCode(201, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var command = new DeleteListCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}