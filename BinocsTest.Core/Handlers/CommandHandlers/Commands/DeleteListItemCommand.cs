using MediatR;

namespace BinocsTest.Core.Handlers.CommandHandlers.Commands
{
    public record DeleteListItemCommand(Guid Id) : IRequest;
}
