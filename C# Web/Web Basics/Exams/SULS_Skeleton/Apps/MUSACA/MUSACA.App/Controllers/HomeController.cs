using MUSACA.App.ViewModels.Orders;
using MUSACA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SIS.MvcFramework.Mapping;
using MUSACA.App.ViewModels.Products;

namespace MUSACA.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            OrderHomeViewModel orderHomeViewModel = new OrderHomeViewModel();

            if (this.IsLoggedIn())
            {
                var order = this.orderService
                    .GetCurrentActiveOrderByCashierId(this.User.Id);

                orderHomeViewModel = order.To<OrderHomeViewModel>();

                orderHomeViewModel.Products.Clear();

                foreach (var orderProduct in order.Products)
                {
                    ProductHomeViewModel productHomeViewModel = orderProduct.To<ProductHomeViewModel>();
                    orderHomeViewModel.Products.Add(productHomeViewModel);
                }
            }

            return this.View(orderHomeViewModel);
        }
    }
}