using Microsoft.EntityFrameworkCore;
using MUSACA.Data;
using MUSACA.Models;
using MUSACA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MUSACA.Services
{
    public class OrderService : IOrderService
    {
        private readonly MUSACAContext context;

        public OrderService(MUSACAContext context)
        {
            this.context = context;
        }

        public bool AddProductToCurrentActiveOrder(string productId, string userId)
        {
            var product = this.context
                .Products
                .SingleOrDefault(p => p.Id == productId);

            var currentOrder = this.GetCurrentActiveOrderByCashierId(userId);
            currentOrder.Products.Add(new OrderProduct
            {
                Product = product,
            });

            this.context.Update(currentOrder);
            this.context.SaveChanges();

            return true;
        }

        public Order CompleteOrder(string userId, string orderId)
        {
            var order = this.context.Orders
                .SingleOrDefault(o => o.CashierId == userId);

            order.IssuedOn = DateTime.UtcNow;
            order.Status = OrderStatus.Completed;

            this.context.Update(order);
            this.context.SaveChanges();

            this.CreateOrder(new Order { CashierId = userId });

            return order;
        }

        public Order CreateOrder(Order order)
        {
            this.context.Add(order);
            this.context.SaveChanges();

            return order;
        }

        public List<Order> GetAllCompletedOrdersByCashierId(string userId)
            => this.context.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .Where(order => order.CashierId == userId)
                .Where(order => order.Status == OrderStatus.Completed)
                .ToList();

        public Order GetCurrentActiveOrderByCashierId(string userId)
            => this.context.Orders
            .Include(order => order.Products)
            .ThenInclude(orderProduct => orderProduct.Product)
            .Include(order => order.Cashier)
            .SingleOrDefault(order => order.CashierId == userId && order.Status == OrderStatus.Active);
    }
}
