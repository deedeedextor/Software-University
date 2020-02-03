using SULS.Data;
using SULS.Models;
using System;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly SULSContext context;
        private readonly Random random;
        private readonly IProblemService problemService;

        public SubmissionService(SULSContext context, Random random, IProblemService problemService)
        {
            this.context = context;
            this.random = random;
            this.problemService = problemService;
        }

        public Submission CreateSubmission(string code, string problemId, string userId)
        {
            var problemPoints = this.problemService.GetById(problemId).Points;

            var submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                CreatedOn = DateTime.UtcNow,
                AchievedResult = this.random.Next(0, problemPoints)
            };

            this.context.Submissions.Add(submission);
            this.context.SaveChanges();

            return submission;
        }

        public bool DeleteById(string id)
        {
            var submission = this.context.Submissions
                .FirstOrDefault(s => s.Id == id);

            if (submission == null)
            {
                return false;
            }

            this.context.Submissions.Remove(submission);
            this.context.SaveChanges();

            return true;
        }

        public int GetSubmissionsCountById(string id)
            => this.context.Submissions.Count(s => s.ProblemId == id);

        public IQueryable<Submission> GetSubmissionsForProblemById(string problemId)
            => this.context.Submissions
            .Where(s => s.ProblemId == problemId);
    }
}
