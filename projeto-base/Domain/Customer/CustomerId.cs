using System;

namespace MassTransitTutorial.Domain
{
    public class CustomerId : IIdentity
    {
        public string Id { get; private set; }

        public static CustomerId New() => new CustomerId
        {
            Id = Guid.NewGuid().ToString()
        };

        public static CustomerId FromValue(Guid value) => new CustomerId
        {
            Id = value.ToString()
        };
    }
}