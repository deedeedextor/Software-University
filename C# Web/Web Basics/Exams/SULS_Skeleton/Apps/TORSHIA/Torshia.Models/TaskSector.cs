using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class TaskSector
    {
        public string Id { get; set; }

        public string TaskId { get; set; }

        public virtual Task Task { get; set; }

        public Sector Sector { get; set; }
    }
}
