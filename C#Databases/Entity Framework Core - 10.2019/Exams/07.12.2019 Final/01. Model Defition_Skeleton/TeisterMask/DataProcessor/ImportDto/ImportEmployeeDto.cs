using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ExportBusiestEmployeeDto
    {
        [Required, StringLength(40), MinLength(3), RegularExpression("^(A-Z)|(a-Z)|.*(0-9)+$")]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}")]
        public string Phone { get; set; }

        [JsonProperty("Tasks")]
        public ICollection<int> Tasks { get; set; }
    }
}
