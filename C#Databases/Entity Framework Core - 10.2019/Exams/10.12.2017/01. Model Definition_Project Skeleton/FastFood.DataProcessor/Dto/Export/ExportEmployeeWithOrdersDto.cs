using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataProcessor.Dto.Export
{
    public class ExportEmployeeWithOrdersDto
    {
        public string Name { get; set; }

        public ExportOrdersByEmployeeDto[] Orders { get; set; }

        public decimal TotalMade { get; set; }
    }
}
