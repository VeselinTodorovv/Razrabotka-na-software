using WebShop.Infrastructure.Data;

using WebShopApp.Core.Contracts;
using WebShopApp.Infrastructure.Data.Domain;

namespace WebShopApp.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(int productId, string userId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                return false;
            }

            Order order = new()
            {
                UserId = userId,
                Quantity = quantity,
                Discount = product.Discount,
                OrderDate = DateTime.Now,
                Price = product.Price,
                ProductId = product.Id
            };

            product.Quantity -= quantity;

            _context.Products.Update(product);
            _context.Orders.Add(order);

            return _context.SaveChanges() != 0;
        }

        public List<Order> GetOrderByUser(string userId)
        {
            return _context.Orders.Where(x => x.UserId == userId)
                .OrderByDescending(x => x.OrderDate)
                .ToList();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.OrderByDescending(x => x.OrderDate).ToList();
        }

        public bool RemoveById(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null) 
            {
                return false;
            }

            _context.Orders.Remove(order);

            return _context.SaveChanges() != 0;
        }

        public bool UpdateOrder(int orderId, int productId, string userId, int quantity)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);

            return _context.SaveChanges() != 0;
        }
    }
}
