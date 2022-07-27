namespace DM.Shared.Application.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        void Handle(TCommand command);
        Task HandleAsync(TCommand command);
    }
}
