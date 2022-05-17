using BinocsTest.Core.Handlers.RequestHandlers.Requests;
using BinocsTest.Core.Handlers.RequestHandlers.Results;
using BinocsTest.Core.Repository.Repositories;
using MediatR;

namespace BinocsTest.Core.Handlers.RequestHandlers
{
    public class GetTotalCountRequestHandler : IRequestHandler<GetTotalCountRequest, GetTotalCountResult>
    {
        readonly IListRepository _listRepository;

        public GetTotalCountRequestHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<GetTotalCountResult> Handle(GetTotalCountRequest request, CancellationToken cancellationToken)
        {
            var response = await _listRepository.GetTotalListAndItemCount();

            return new GetTotalCountResult
            {
                ItemsCount = response.ItemsCount,
                ListsCount = response.ListsCount
            };
        }
    }
}
