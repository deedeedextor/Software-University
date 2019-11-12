using Newtonsoft.Json;

namespace ProductShop
{
    public class CategoryResultModel
    {
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "productName")]
        public int ProductCount { get; set; }

        [JsonProperty(PropertyName = "averagePrice")]
        public decimal AveragePrice { get; set; }

        [JsonProperty(PropertyName = "totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}