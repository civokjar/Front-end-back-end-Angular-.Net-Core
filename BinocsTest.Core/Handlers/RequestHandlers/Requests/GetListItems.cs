using BinocsTest.Core.Handlers.RequestHandlers.Results;
using MediatR;

namespace BinocsTest.Core.Handlers.RequestHandlers.Requests
{
    public record GetListItemsRequest(Guid Id) : IRequest<GetListItemsResult>;
}