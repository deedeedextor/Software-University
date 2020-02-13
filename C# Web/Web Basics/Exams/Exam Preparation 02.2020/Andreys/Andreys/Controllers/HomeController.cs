namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        { 
            return this.Index();
        }

        private HttpResponse Index()
        {
            if (IsUserLoggedIn())
            {
                var productsViewModel = new ProductHomeAllViewModel
                {
                    Products = this.productsService.GetAll
                    (x => new ProductAllViewModel
                    {
                        Id = x.Id,
                        ImageUrl = x.ImageUrl,
                        Name = x.Name,
                        Price = x.Price,
                    }),
                };

                return this.View(productsViewModel, "Home");
            }

            return this.View();
        }
    }
}
