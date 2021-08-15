using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public class TransactionType
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Name { get; set; }
    }
}
