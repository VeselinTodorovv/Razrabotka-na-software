﻿using WebShopApp.Infrastructure.Data.Domain;

namespace WebShopApp.Core.Contracts
{
    public interface IOrderService
    {
        bool Create(int productId, string userId, int quantity);
        List<Order> GetOrders();
        List<Order> GetOrderByUser(string userId);
        bool RemoveById(int orderId);
        bool UpdateOrder(int orderId, int productId, string userId, int quantity);
    }
}
