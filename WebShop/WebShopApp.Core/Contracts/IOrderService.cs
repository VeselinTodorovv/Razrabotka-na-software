﻿using WebShopApp.Infrastructure.Data.Domain;

namespace WebShopApp.Core.Contracts
{
    public interface IOrderService
    {
        bool Create(int productId, string userId, int quantity);
        List<Order> GetOrders();
        List<Order> GetOrdersByUser(string userId);
        Order GetOrderById(int orderId);
        bool RemoveById(int orderId);
        bool UpdateOrder(int orderId, int productId, string userId, int quantity);
    }
}
