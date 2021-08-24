using System;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public string PlainId => Id.ToString();

        public DateTimeOffset TransactionDate { get; set; }

        public Guid TransactionTypeId { get; set; }

        public TransactionType? TransactionType { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Description { get; set; }

        public Guid SellerId { get; set; }
        public Member? Seller { get; set; }

        public Guid BuyerId { get; set; }
        public Member? Buyer { get; set; }

        public int Value { get; set; }


    }
}
