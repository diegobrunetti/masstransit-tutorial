using System;
using System.ComponentModel.DataAnnotations;

namespace MassTransitTutorial.Persistence
{
    public class TbCustomer
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MinLength(2), MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public int Type { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}