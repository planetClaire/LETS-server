using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Entities
{
    public class MemberType
    {
        public Guid Id { get; set; }

        public string Uid => Id.ToString();

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public ICollection<Member> Members { get; set; } = new List<Member>();
    }
}
