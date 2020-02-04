﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class Problem
    {
        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }

        [Range(50, 300)]
        public int Points { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}
