using Andreys.Models;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    public interface IProductsService
    {
        void Add(string name, string description, string imageUrl, string category, string gender, decimal price);

        IEnumerable<T> GetAll<T>(Func<Product, T> selectFunc);

        ProductDetailViewModel GetDetails(int id);

        void Delete(int id);
    }
}
