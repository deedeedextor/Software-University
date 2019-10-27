namespace MiniORM.App.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class EmployeeProject
    {
        [Key]
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        [Key]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public Project Project { get; set; }
    }
}
