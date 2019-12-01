using Newtonsoft.Json;

namespace FastFood.DataProcessor.Dto.Import
{
    public class ImportEmployeeDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Age")]
        public int Age { get; set; }

        [JsonProperty("Position")]
        public string Position { get; set; }
    }
}
