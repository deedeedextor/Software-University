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

        public string Create(string title, string dueDate, string description, string participants, params object[] sectors)
        {
            //var sectorsString = sectors.Where(s //=> !string.IsNullOrWhiteSpace(s))
            //    .ToArray();

            var task = new Task
            {
                Title = title,
                DueDate = DateTime.ParseExact(dueDate, "mm/dd/yyyy", CultureInfo.InvariantCulture),
                Description = description,
                IsReported = false,
                Participants = participants
            };

            foreach (var sectorStr in sectors)
            {
                var validSector = Enum.TryParse<Sector>(sectorStr.ToString(), out Sector sector);

                if (validSector)
                {
                    task.AffectedSectors.Add(new TaskSector { Sector = sector });
                }
            }

            this.db.Tasks.Add(task);
            this.db.SaveChanges();

            return task.Id;
        }

        public IQueryable<Task> GetAllByName()
        {
            return this.db.Tasks;
        }

        public Task GetTaskById(string id)
        {
            var taskFromDb = this.db.Tasks
                .SingleOrDefault(t => t.Id == id);

            return taskFromDb;
        }
    }
}
