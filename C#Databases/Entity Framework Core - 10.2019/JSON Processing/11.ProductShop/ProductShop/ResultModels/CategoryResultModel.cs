using Newtonsoft.Json;

namespace ProductShop
{
    public class CategoryResultModel
    {
        //[JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        //[JsonProperty(PropertyName = "productName")]
        public int ProductsCount { get; set; }

        //[JsonProperty(PropertyName = "averagePrice")]
        public string AveragePrice { get; set; }

        //[JsonProperty(PropertyName = "totalRevenue")]
        public string TotalRevenue { get; set; }
    }
}