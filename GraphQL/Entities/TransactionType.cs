using System;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Entities
{
    public class TransactionType
    {
        public Guid Id { get; set; }

        public string Uid => Id.ToString();

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
