using System;
using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class Report
    {
        public Report()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public ReportStatus Status { get; set; }

        public DateTime ReportedOn { get; set; }

        public string TaskId { get; set; }

        public virtual Task Task { get; set; }

        public string ReporterId { get; set; }

        public virtual User Reporter { get; set; }
    }
}
