using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Torshia.Models;
using Torshia.Models.Enums;
using Totshia.Data;

namespace Torshia.Services
{
    public class TasksService : ITasksService
    {
        private readonly TORSHIAContext db;

        public TasksService(TORSHIAContext db)
        {
            this.db = db;
        }

        public string Create(string title, string dueDate, string description, string participants, List<string> affectedSectors)
        {
            var task = new Task
            {
                Title = title,
                DueDate = DateTime.ParseExact(dueDate, "mm/dd/yyyy", CultureInfo.InvariantCulture),
                Description = description,
                IsReported = false,
                Participants = participants
            };

            if (affectedSectors.Count != 0)
            {
                foreach (var sectorStr in affectedSectors)
                {
                    var validSector = Enum.TryParse<Sector>(sectorStr, out Sector sector);

                    if (validSector)
                    {
                        task.AffectedSectors.Add(new TaskSector { Sector = sector });
                    }
                }
            }

            this.db.Tasks.Add(task);
            this.db.SaveChanges();

            return task.Id;
        }

        public ICollection<Task> GetAllUnreportedTasks()
            => this.db
                .Tasks
                .Include(t => t.AffectedSectors)
                .Where(t => t.IsReported == false)
                .ToList();

        public Task GetTaskById(string id)
        {
            var taskFromDb = this.db.Tasks
                .SingleOrDefault(t => t.Id == id);

            return taskFromDb;
        }
    }
}
