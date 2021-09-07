using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Entities
{
    public class Locality
    {
        public Guid Id { get; set; }

        public string PlainId => Id.ToString();

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Postcode { get; set; }

        public ICollection<Member> Members { get; set; } = new List<Member>();
    }
}
