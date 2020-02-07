using MUSACA.App.ViewModels.Products;
using MUSACA.Models;
using MUSACA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;
using System.Linq;

namespace MUSACA.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductsController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [Authorize]
        public IActionResult All()
        {
            var products = this.productService.GetAll()
                .Select(p => new ProductAllViewModel
                {
                    Name = p.Name,
                    Price = p.Price.ToString(),
                })
                .ToList();

            return this.View(products);
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ProductCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };

            this.productService.CreateProduct(product);

            return this.Redirect("/Products/All");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Order(ProductOrderViewModel model)
        {
            var productToOrder = this.productService
                .GetByName(model.Product);

            this.orderService.AddProductToCurrentActiveOrder(productToOrder.Id, this.User.Id);

            return this.Redirect("/");
        }
    }
}
