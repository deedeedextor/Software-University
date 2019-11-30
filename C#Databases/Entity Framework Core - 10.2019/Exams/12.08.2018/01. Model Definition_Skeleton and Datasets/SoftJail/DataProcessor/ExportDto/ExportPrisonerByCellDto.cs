using Newtonsoft.Json;
using System.Collections.Generic;

namespace SoftJail.DataProcessor.ExportDto
{
    public class ExportPrisonerByCellDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string FullName { get; set; }

        [JsonProperty("CellNumber")]
        public int CellNumber { get; set; }

        [JsonProperty("Officers")]
        public ICollection<ExportOfficerByPrisonerDto> Officers { get; set; }

        [JsonProperty("TotalOfficerSalary")]
        public decimal TotalOfficerSalary { get; set; }
    }
}
