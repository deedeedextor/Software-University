using SULS.Data;
using SULS.Models;
using System.Linq;

namespace SULS.Services
{
    public class ProblemService : IProblemService
    {
        private readonly SULSContext context;

        public ProblemService(SULSContext context)
        {
            this.context = context;
        }

        public Problem CreateProblem(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.context.Problems.Add(problem);
            this.context.SaveChanges();

            return problem;
        }

        public IQueryable<Problem> GetAll()
            => this.context.Problems;

        public Problem GetById(string id)
            => this.context.Problems
            .FirstOrDefault(problem => problem.Id == id);
    }
}
