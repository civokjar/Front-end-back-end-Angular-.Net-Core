using BinocsTest.Core.Handlers.CommandHandlers.Results;
using MediatR;

namespace BinocsTest.Core.Handlers.CommandHandlers.Commands
{
    public record CreateListCommand(string Name) : IRequest<CreateListResult>;
}
