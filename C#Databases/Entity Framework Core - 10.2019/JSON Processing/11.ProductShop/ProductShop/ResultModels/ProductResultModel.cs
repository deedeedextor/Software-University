using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace ProductShop
{
    public  class ProductResultModel
    {
        //[JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        //[JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        //[JsonProperty(PropertyName = "seller")]
        public string Seller { get; set; }

        public ICollection<SoldProductsResultModel> SoldProducts { get; set; }
    }
}