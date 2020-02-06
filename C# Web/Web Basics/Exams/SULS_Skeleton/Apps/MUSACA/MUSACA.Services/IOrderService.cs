using MUSACA.Models;
using System.Collections.Generic;

namespace MUSACA.Services
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);

        Order GetCurrentActiveOrderByCashierId(string userId);

        Order CompleteOrder(string userId, string orderId);

        bool AddProductToCurrentActiveOrder(string productId, string userId);

        List<Order> GetAllCompletedOrdersByCashierId(string userId);
    }
}
