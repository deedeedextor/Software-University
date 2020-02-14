using System;
using System.Collections.Generic;
using System.Linq;
using Torshia.Models;

namespace Torshia.Services
{
    public interface ITasksService
    {
        string Create(string title, string dueDate, string description, string participants, List<string> affectedSectors);

        ICollection<Task> GetAllUnreportedTasks();

        Task GetTaskById(string id);
    }
}
