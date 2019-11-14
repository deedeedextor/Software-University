using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer
{
    public class CarsWithPartsExportDto
    {
        [JsonProperty(PropertyName = "car")]
        public ICollection<CarsPartsExportDto> Cars { get; set; }
    }
}