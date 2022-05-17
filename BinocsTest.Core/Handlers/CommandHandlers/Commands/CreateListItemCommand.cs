using MediatR;

namespace BinocsTest.Core.Handlers.CommandHandlers.Commands
{
    public record CreateListItemCommand(Guid ListId, string Content) : IRequest<Guid>;
}
