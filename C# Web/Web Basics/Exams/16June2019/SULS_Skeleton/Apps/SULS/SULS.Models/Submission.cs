using SIS.MvcFramework.Attributes.Validation;
using System;

namespace SULS.Models
{
    public class Submission
    {
        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [RequiredSis]
        [StringLengthSis(30, 800, "Invalid code length!")]
        public string Code { get; set; }

        [RangeSis(0, 300, "Invalid achieved result length!")]
        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }

        public Problem Problem { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
