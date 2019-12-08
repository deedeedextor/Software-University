using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportBusiestEmployeesDto
    {
        public string Username { get; set; }

        public ExportTasksByProjectDto[] Tasks { get; set; }
    }
}
