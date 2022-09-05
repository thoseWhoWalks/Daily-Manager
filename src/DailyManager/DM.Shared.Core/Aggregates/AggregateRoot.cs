using DM.Shared.Core.Events;

namespace DM.Shared.Core.Aggregates
{
    public abstract class AggregateRoot
    {
        private readonly List<IEvent> _events = new();
        public IEnumerable<IEvent> Events => _events.AsReadOnly();

        protected void AddEvent(IEvent @event)
            => _events.Add(@event);

        protected void ClearEvents()
            => _events.Clear();
    }
}
