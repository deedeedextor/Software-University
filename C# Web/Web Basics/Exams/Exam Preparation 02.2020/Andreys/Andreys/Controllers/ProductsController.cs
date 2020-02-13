using Andreys.Services;
using Andreys.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductInputViewModel input)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name must be at least 4 characters and at most 20");
            }

            if (input.Description.Length > 10)
            {
                return this.Error("Description must be up to 10 characters");
            }

            if (input.Price < 0)
            {
                return this.Error("Price must be positive number");
            }

            this.productsService.Add(input.Name, input.Description, input.ImageUrl, input.Category, input.Gender, input.Price);

            return this.Redirect("/");
        }

        
        public HttpResponse Details(int id)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }

            var viewModel = this.productsService.GetDetails(id);

            return this.View(viewModel);
        }

        public HttpResponse Delete(int id)
        {
            this.productsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
