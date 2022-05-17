using BinocsTest.Core.Handlers.CommandHandlers.Commands;
using BinocsTest.Core.Handlers.CommandHandlers.Results;
using BinocsTest.Core.Model.Entities;
using BinocsTest.Core.Repository.Repositories;
using MediatR;

namespace BinocsTest.Core.Handlers.CommandHandlers
{
    class CreateListCommandHandler : IRequestHandler<CreateListCommand, CreateListResult>
    {
        private readonly IListRepository _listRepository;

        public CreateListCommandHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<CreateListResult> Handle(CreateListCommand request, CancellationToken cancellationToken)
        {
            var entity = new ListEntity { Id = Guid.NewGuid(), Name = request.Name };
            await _listRepository.CreateAsync(entity);

            return new CreateListResult
            {
                Id = entity.Id,
                Name = request.Name,
            };
        }
    }

}
