using System;
using System.Collections.Generic;
using System.Linq;
using Torshia.Models;

namespace Torshia.Services
{
    public interface ITasksService
    {
        string Create(string title, string DueDate, string description, string participants, params object[] sectors);

        IQueryable<Task> GetAllByName();

        Task GetTaskById(string id);
    }
}
