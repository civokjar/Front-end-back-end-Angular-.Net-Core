using BinocsTest.Core.Handlers.CommandHandlers.Commands;
using BinocsTest.Core.Repository.Repositories;
using MediatR;

namespace BinocsTest.Core.Handlers.CommandHandlers
{
    class DeleteListItemCommandHandler : IRequestHandler<DeleteListItemCommand>
    {
        private readonly IListItemRepository _itemRepository;

        public DeleteListItemCommandHandler(IListItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Unit> Handle(DeleteListItemCommand request, CancellationToken cancellationToken)
        {
            await _itemRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }

}
