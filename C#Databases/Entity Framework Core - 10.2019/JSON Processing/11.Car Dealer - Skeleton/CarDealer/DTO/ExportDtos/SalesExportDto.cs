﻿using Newtonsoft.Json;

namespace CarDealer
{
    public class SalesExportDto
    {
        [JsonProperty(PropertyName = "car")]
        public CarsPartsExportDto Car { get; set; }

        [JsonProperty(PropertyName = "customerName")]
        public string CustomerName { get; set; }

        public string Discount { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "priceWithDiscount")]
        public string PriceWithDiscount { get; set; }
    }
}