using MUSACA.Models;
using System.Collections.Generic;

namespace MUSACA.Services
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product GetByName(string name);

        Product CreateProduct(Product product);
    }
}
