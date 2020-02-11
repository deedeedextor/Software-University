using System;
using System.Collections.Generic;

namespace Torshia.Models
{
    public class Task
    {

        public Task()
        {
            this.Id = Guid.NewGuid().ToString();
            this.AffectedSectors = new HashSet<TaskSector>();
            this.Reports = new HashSet<Report>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public virtual ICollection<TaskSector> AffectedSectors { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
