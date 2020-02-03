using System;

namespace SULS.App.ViewModels.Submissions
{
    public class DetailsSubmissionViewModel
    {
        private int maxPoints;
        private int achievedResult;

        public string Id { get; set; }

        public string Username { get; set; }

        public int FinalPoints { get; set; }

        public int AchievedResult
        {
            get => int.Parse(Math.Round((this.achievedResult / (double)this.maxPoints) * 100).ToString());
            set => this.achievedResult = value;
        }

        public int MaxPoints
        {
            get => this.MaxPoints;
            set => this.maxPoints = value;
        }

        public string CreatedOn { get; set; }
    }
}
