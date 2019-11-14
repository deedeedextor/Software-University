using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProductShop
{
    public  class UserResultModel
    {
        //[JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        //[JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        //[JsonProperty(PropertyName = "soldProducts")]
        public ICollection<SoldProductsResultModel> SoldProducts { get; set; }
    }
}