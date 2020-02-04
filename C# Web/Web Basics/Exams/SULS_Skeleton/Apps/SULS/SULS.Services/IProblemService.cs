using SULS.Models;
using System.Linq;

namespace SULS.Services
{
    public interface IProblemService
    {
        Problem CreateProblem(string name, int points);

        IQueryable<Problem> GetAll();

        Problem GetById(string id);
    }
}
