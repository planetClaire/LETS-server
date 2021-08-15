using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public class NoticeType
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Type { get; set; }

        public ICollection<Notice> Notices { get; set; } = new List<Notice>();
    }
}
