using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;

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

        [RequiredSis]
        [StringLengthSis(5, 20, "Invalid name length!")]
        public string Name { get; set; }

        [RangeSis(50, 300, "Invalid range number!")]
        public int Points { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}
