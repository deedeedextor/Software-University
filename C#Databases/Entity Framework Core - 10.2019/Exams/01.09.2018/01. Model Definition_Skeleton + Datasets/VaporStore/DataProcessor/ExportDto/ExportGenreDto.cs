using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.DataProcessor.ExportDto
{
    public class ExportGenreDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Games")]
        public ICollection<ExportGameByGenreDto> Games { get; set; }

        [JsonProperty("TotalPlayers")]
        public int TotalPlayers { get; set; }
    }
}
