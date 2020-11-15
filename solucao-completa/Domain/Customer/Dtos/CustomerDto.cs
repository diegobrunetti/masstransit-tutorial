using System;

namespace MassTransitTutorial.Domain
{
    public class CustomerDto
    {
        public CustomerId CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}