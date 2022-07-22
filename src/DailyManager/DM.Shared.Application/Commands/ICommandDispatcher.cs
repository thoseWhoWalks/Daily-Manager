namespace DM.Shared.Application.Commands
{
    public interface ICommandDispatcher
    {
        void Send<TCommand>(TCommand command) 
            where TCommand : class, ICommand;
        Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) 
            where TCommand : class, ICommand;
    }
}
