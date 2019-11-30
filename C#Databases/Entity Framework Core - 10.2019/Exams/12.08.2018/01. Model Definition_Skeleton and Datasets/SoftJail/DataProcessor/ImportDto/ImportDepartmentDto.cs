using Newtonsoft.Json;
using SoftJail.Data.Models;
using System.Collections.Generic;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Cells")]
        public ICollection<Cell> Cells { get; set; }
    }
}
