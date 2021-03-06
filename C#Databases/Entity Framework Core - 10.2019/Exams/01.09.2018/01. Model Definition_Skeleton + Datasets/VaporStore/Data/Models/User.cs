﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(20), MinLength(3)]
        public string Username { get; set; }

        [Required, RegularExpression(@"^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, Range(3, 103)]
        public int Age { get; set; }

        public ICollection<Card> Cards { get; set; } = new HashSet<Card>();
    }
}
