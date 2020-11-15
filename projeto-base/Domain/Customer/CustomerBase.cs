using System;

namespace MassTransitTutorial.Domain
{
    public abstract class CustomerBase
    {
        public CustomerId CustomerId { get; protected set; }
        public string Name { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public Type Type { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected CustomerBase() { }

        public CustomerBase(string name, DateTime birthDate, Type type)
        {
            Check.NotNull(name, "The customer name is invalid.");
            Check.NotEqual(type, default, "The customer type is invalid.");
            Check.IsNotMinor(birthDate, "Customer need to be of legal age.");
        }
    }
}
