﻿namespace MiniORM.App.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class EmployeesProjects
    {
        [Key]
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        [Key]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        public Employees Employee { get; set; }

        public Projects Project { get; set; }
    }
}
