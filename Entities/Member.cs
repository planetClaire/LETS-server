using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public class Member
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
    }
}
