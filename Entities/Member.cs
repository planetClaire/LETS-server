using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public class Member
    {
        public Guid Id { get; set; }

        public string PlainId => Id.ToString();
        public Guid MemberTypeId { get; set; }
        public MemberType? MemberType { get; set; }

        [Required]
        [StringLength(200)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string? LastName { get; set; }

        [StringLength(1000)]
        public virtual string? Website { get; set; }

        public Guid LocalityId { get; set; }

        public Locality? Locality { get; set; }

        public ICollection<Notice> Notices { get; set; } = new List<Notice>();

        public ICollection<Transaction> Sales { get; set; } = new List<Transaction>();
        public ICollection<Transaction> Purchases { get; set; } = new List<Transaction>();
    }
}
