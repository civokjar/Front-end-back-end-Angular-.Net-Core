using BinocsTest.Core.Handlers.RequestHandlers.Requests;
using BinocsTest.Core.Handlers.RequestHandlers.Results;
using BinocsTest.Core.Repository.Repositories;
using MediatR;

namespace BinocsTest.Core.Handlers.RequestHandlers
{
    public partial class GetAllListsHandler
    {
        class GetListItemsRequestHandler : IRequestHandler<GetListItemsRequest, GetListItemsResult>
        {
            private readonly IListItemRepository _itemRepository;

            public GetListItemsRequestHandler(IListItemRepository itemRepository)
            {
                _itemRepository = itemRepository;
            }
            public async Task<GetListItemsResult> Handle(GetListItemsRequest request, CancellationToken cancellationToken)
            {
                var response = new GetListItemsResult();

                var listItems = await _itemRepository.GetByListIdAsync(request.Id);

                response.ListItems = listItems.ToList();

                return response;
            }
        }
    }
}
