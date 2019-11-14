using System.Collections.Generic;

namespace ProductShop
{
    public class SoldProductsToUserResultModel
    {
        public int Count { get; set; }

        public ICollection<SoldProductsResultModel> Products { get; set; }
    }
}