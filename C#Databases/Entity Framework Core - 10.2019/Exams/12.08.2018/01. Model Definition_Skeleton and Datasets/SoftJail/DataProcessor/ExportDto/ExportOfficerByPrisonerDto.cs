namespace SoftJail.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    public class ExportOfficerByPrisonerDto
    {
        [JsonProperty("OfficerName")]
        public string FullName { get; set; }

        [JsonProperty("Department")]
        public string Department { get; set; }
    }
}