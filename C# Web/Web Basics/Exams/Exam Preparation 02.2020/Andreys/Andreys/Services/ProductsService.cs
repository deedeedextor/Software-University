using Andreys.Data;
using Andreys.Models;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void Add(string name, string description, string imageUrl, string category, string gender, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Category = (Category)Enum.Parse(typeof(Category), category, true),
                Gender = (Gender)Enum.Parse(typeof(Gender), gender, true),
                Price = price
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = this.db.Products.Find(id);

            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

        public IEnumerable<T> GetAll<T>(Func<Product, T> selectFunc)
        {
            var products = this.db.Products
                .Select(selectFunc).ToList();

            return products;
        }

        public ProductDetailViewModel GetDetails(int id)
        {
            var viewModel = this.db.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductDetailViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Gender = x.Gender.ToString(),
                    Category = x.Category.ToString(),
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Price = x.Price
                })
                .FirstOrDefault();

            return viewModel;
        }
    }
}
