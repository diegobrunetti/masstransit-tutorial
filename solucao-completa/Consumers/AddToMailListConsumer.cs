using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransitTutorial.Domain.Events;

namespace MassTransitTutorial.Consumers
{
    public class AddToMailListConsumer : IConsumer<CustomerCreatedEvent>
    {
        public Task Consume(ConsumeContext<CustomerCreatedEvent> context)
        {
            Console.WriteLine($"Customer {context.Message.CustomerId} added to mail list.");
            return Task.CompletedTask;
        }
    }
}