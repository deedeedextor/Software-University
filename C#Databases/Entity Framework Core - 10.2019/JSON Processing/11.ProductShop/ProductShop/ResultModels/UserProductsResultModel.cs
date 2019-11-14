using System.Collections.Generic;

namespace ProductShop
{
    public class UserProductsResultModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public SoldProductsToUserResultModel SoldProducts { get; set; }
    }
}