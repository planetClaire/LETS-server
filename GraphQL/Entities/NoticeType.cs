using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Entities
{
    public class NoticeType
    {
        public Guid Id { get; set; }

        public string PlainId => Id.ToString();

        [Required]
        [StringLength(200)]
        public string Type { get; set; }

        public ICollection<Notice> Notices { get; set; } = new List<Notice>();
    }
}
