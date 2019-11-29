﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Mail
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required, RegularExpression(@"^[A-z,a-z,0-9, ]+[str.]$")]
        public string Address { get; set; }

        [Required, ForeignKey(nameof(Prisoner))]
        public int PrisonerId { get; set; }

        public Prisoner Prisoner { get; set; }
    }
}
