using DM.Shared.Application.Commands;
using MediatR;

namespace DM.Shared.Infrastructure.Commands
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        #region Dependencies

        private readonly IMediator _mediator;

        #endregion

        public CommandDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        void ICommandDispatcher.Send<TCommand>(TCommand command)
        {
            _mediator.Publish(command).GetAwaiter().GetResult();
        }

        async Task ICommandDispatcher.SendAsync<TCommand>(TCommand command, 
            CancellationToken cancellationToken)
        {
            await _mediator.Publish(command, cancellationToken);
        }
    }
}
