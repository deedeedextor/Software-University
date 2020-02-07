using MUSACA.Data;
using MUSACA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace MUSACA.App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Cashout()
        {
            var currentOrder = this.orderService.GetCurrentActiveOrderByCashierId(this.User.Id);

            this.orderService.CompleteOrder(currentOrder.Id, this.User.Id);

            return this.Redirect("/");
        }
    }
}
