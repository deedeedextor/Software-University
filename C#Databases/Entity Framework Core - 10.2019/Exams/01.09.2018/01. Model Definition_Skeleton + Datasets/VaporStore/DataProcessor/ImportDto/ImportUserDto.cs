using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportUserDto
    {
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        [JsonProperty("Cards")]
        public ICollection<ImportCardDto> Cards { get; set; }
    }
}
