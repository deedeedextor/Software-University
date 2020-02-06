using MUSACA.Data;
using MUSACA.Models;
using System.Collections.Generic;
using System.Linq;

namespace MUSACA.Services
{
    public class ProductService : IProductService
    {
        private readonly MUSACAContext context;

        public ProductService(MUSACAContext context)
        {
            this.context = context;
        }

        public Product CreateProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();

            return product;
        }

        public List<Product> GetAll()
            => this.context.Products.ToList();

        public Product GetByName(string name)
            => this.context.Products
            .SingleOrDefault(product => product.Name == name);
    }
}
