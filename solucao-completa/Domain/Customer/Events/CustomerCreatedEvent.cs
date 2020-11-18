using System;

namespace MassTransitTutorial.Domain.Events
{
    public interface CustomerCreatedEvent
    {
        string CustomerId { get; }
        string Name { get; }
        DateTime BirthDate { get; }
        string Type { get; }
        DateTime CreatedAt { get; }
    }
}