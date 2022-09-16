using DM.Shared.Application.Events;
using DM.Shared.OutBox.Context;
using DM.Shared.OutBox.Entities;

namespace DM.Shared.Infrastructure.Events
{
    public abstract class EventDispatcher : IEventDispatcher
    {
        #region Dependecies
        private readonly OutBoxDbContext _dbContext;
        #endregion

        public EventDispatcher(OutBoxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        void IEventDispatcher.Publish<TEvent>(TEvent @event)
            => _dbContext.Add(new OutBoxMessage(@event));

        void IEventDispatcher.Publish<TEvent>(TEvent[] @event)
        {
            var messages = @event.Select(e => new OutBoxMessage(e));

            _dbContext.Add(messages);
        }

        async Task IEventDispatcher.PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken)
            => await _dbContext.AddAsync(new OutBoxMessage(@event), cancellationToken);

        async Task IEventDispatcher.PublishAsync<TEvent>(TEvent[] @event, CancellationToken cancellationToken)
        {
            var messages = @event.Select(e => new OutBoxMessage(e));

            await _dbContext.AddAsync(messages, cancellationToken);
        }
    }
}
