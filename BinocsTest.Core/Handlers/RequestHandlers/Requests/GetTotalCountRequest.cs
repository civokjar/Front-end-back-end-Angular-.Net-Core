using BinocsTest.Core.Handlers.RequestHandlers.Results;
using MediatR;

namespace BinocsTest.Core.Handlers.RequestHandlers.Requests
{
    public record GetTotalCountRequest : IRequest<GetTotalCountResult>;
}