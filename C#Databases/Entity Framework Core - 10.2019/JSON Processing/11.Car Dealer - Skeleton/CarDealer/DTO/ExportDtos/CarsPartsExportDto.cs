using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer
{
    public class CarsPartsExportDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }
    }
}