using MediatR;

namespace DM.Shared.Application.Commands
{
    public interface ICommandHandler<in TCommand>
        : IRequestHandler<TCommand>
        where TCommand : class, ICommand
    {
        void Handle(TCommand command);
        Task HandleAsync(TCommand command);
        // Note: Till in-memory dispatcher used, can be moved to base class...etc.
        async Task<Unit> IRequestHandler<TCommand, Unit>.Handle(TCommand command, CancellationToken cancellationToken)
        {
            await HandleAsync(command);

            return Unit.Value;
        }
    }
}
