using BinocsTest.Core.Handlers.RequestHandlers.Requests;
using BinocsTest.Core.Handlers.RequestHandlers.Results;
using BinocsTest.Core.Repository.Repositories;
using MediatR;

namespace BinocsTest.Core.Handlers.RequestHandlers
{
    public partial class GetAllListsRequestHandler : IRequestHandler<GetAllListsRequest, GetAllListsResult>
    {
        private readonly IListRepository _listRepository;

        public GetAllListsRequestHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<GetAllListsResult> Handle(GetAllListsRequest request, CancellationToken cancellationToken)
        {
            var response = new GetAllListsResult();

            var lists = await _listRepository.GetAllAsync();

            response.AllLists = lists.ToList();

            return response;
        }
    }
}
