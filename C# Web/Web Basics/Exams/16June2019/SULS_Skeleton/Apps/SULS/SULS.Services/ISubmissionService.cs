using SULS.Models;
using System.Linq;

namespace SULS.Services
{
    public interface ISubmissionService
    {
        Submission CreateSubmission(string code, string problemId, string userId);

        bool DeleteById(string id);

        IQueryable<Submission> GetSubmissionsForProblemById(string problemId);

        int GetSubmissionsCountById(string id);
    }
}
