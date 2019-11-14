using System.Collections.Generic;

namespace ProductShop
{
    public class UserWithProductsResultModel
    {
        public int UserCount { get; set; }
        public ICollection<UserProductsResultModel> Users { get; set; }
    }
}