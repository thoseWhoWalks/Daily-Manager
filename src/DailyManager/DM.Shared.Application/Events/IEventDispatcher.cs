using DM.Shared.Core.Events;

namespace DM.Shared.Application.Events
{
    public interface IEventDispatcher
    {
        void Publish<TEvent>(TEvent @event)
            where TEvent : class, IEvent;
        void Publish<TEvent>(TEvent[] @event)
            where TEvent : class, IEvent;
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : class, IEvent;
        Task PublishAsync<TEvent>(TEvent[] @event, CancellationToken cancellationToken = default)
            where TEvent : class, IEvent;
    }
}
