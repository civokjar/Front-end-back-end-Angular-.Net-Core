using MediatR;

namespace BinocsTest.Core.Handlers.CommandHandlers.Commands
{
    public record DeleteListCommand(Guid id) : IRequest;

}
