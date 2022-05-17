using BinocsTest.Core.Handlers.CommandHandlers.Commands;
using BinocsTest.Core.Model.Entities;
using BinocsTest.Core.Repository.Repositories;
using MediatR;

namespace BinocsTest.Core.Handlers.CommandHandlers
{
    class CreateListItemCommandHandler : IRequestHandler<CreateListItemCommand,Guid>
    {
        private readonly IListItemRepository _itemRepository;

        public CreateListItemCommandHandler(IListItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Guid> Handle(CreateListItemCommand request, CancellationToken cancellationToken)
        {
            var listItem = new ListItemEntity { Id = Guid.NewGuid(), ListId = request.ListId, Content = request.Content };

            await _itemRepository.CreateAsync(listItem);

            return listItem.Id;
        }
    }
}
