﻿using DM.Shared.Core.Entities;
using DM.Shared.Core.Events;
using Newtonsoft.Json.Linq;

namespace DM.Shared.OutBox.Entities
{
    public class OutBoxMessage : IEntity
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Message { get; } = null!;
        public string Type { get; } = null!;

        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime? ExecutedAt { get; set; }

        private OutBoxMessage()
        {
        }

        public OutBoxMessage(IEvent @event)
        {
            Message = JObject.FromObject(@event).ToString();
            Type = @event.GetType().FullName
                ?? throw new ArgumentNullException();
        }
    }
}
