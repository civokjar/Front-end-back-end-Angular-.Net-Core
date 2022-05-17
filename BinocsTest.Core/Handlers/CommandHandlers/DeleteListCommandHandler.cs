using BinocsTest.Core.Handlers.CommandHandlers.Commands;
using BinocsTest.Core.Repository.Repositories;
using MediatR;

namespace BinocsTest.Core.Handlers.CommandHandlers
{
    class DeleteListCommandHandler : IRequestHandler<DeleteListCommand>
    {
        private readonly IListRepository _listRepository;

        public DeleteListCommandHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<Unit> Handle(DeleteListCommand request, CancellationToken cancellationToken)
        {
            await _listRepository.DeleteAsync(request.id);

            return Unit.Value;
        }
    }
}
