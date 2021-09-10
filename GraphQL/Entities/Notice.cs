﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Entities
{
    public class Notice
    {
        public Guid Id { get; set; }

        public string Uid => Id.ToString();

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string MemberId { get; set; }
        public Member Member { get; set; }

        public Guid NoticeTypeId { get; set; }
        public NoticeType NoticeType { get; set; }
    }
}
