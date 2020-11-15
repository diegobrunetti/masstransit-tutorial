using System;

namespace MassTransitTutorial.Domain
{
    public class Customer : CustomerBase
    {
        public static readonly Customer Empty = new Customer();
        public DateTime? UpdatedAt { get; private set; }

        private Customer() : base() { }

        public Customer(CustomerId id, string name, DateTime birthDate, Type type, DateTime createdAt, DateTime? updatedAt)
            : base(name, birthDate, type)
        {
            CustomerId = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public void ChangeBirthDate(DateTime newDate)
        {
            Check.IsNotMinor(newDate, "The new birthdate is invalid: customer need to be legal of age.");
            BirthDate = newDate.Date;
            UpdatedAt = DateTime.Now;
        }
    }
}
