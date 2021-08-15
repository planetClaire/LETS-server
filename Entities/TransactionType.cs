﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public class TransactionType
    {
        public Guid Id { get; set; }

        public string PlainId => Id.ToString();

        [Required]
        [StringLength(200)]
        public string? Name { get; set; }
    }
}
