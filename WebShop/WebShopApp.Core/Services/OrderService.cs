using WebShop.Infrastructure.Data;

using WebShopApp.Core.Contracts;
using WebShopApp.Infrastructure.Data.Domain;

namespace WebShopApp.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductService _productService;


        public OrderService(ApplicationDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public bool Create(int productId, string userId, int quantity)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == productId);
            if (product == null)
            {
                return false;
            }

            Order order = new()
            {
                OrderDate = DateTime.Now,
                ProductId = product.Id,
                UserId = userId,
                Quantity = quantity,
                Discount = product.Discount,
                Price = product.Price,
            };

            product.Quantity -= quantity;

            _context.Products.Update(product);
            _context.Orders.Add(order);

            return _context.SaveChanges() != 0;
        }

        public Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersByUser(string userId)
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
