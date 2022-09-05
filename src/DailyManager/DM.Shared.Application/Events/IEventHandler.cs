using MediatR;

namespace DM.Shared.Application.Events
{
    public interface IEventHandler<in TEvent> 
        : INotificationHandler<TEvent>
        where TEvent : class, IEvent
    {
        void Handle(TEvent @event);
        Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
        // Note: Till in-memory dispatcher used, can be moved to base class...etc.
        async Task INotificationHandler<TEvent>.Handle(TEvent @event, CancellationToken cancellationToken)
            => await HandleAsync(@event);
    }
}
