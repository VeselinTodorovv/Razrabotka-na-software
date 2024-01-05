using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebShop.Infrastructure.Data;

using WebShopApp.Core.Contracts;

namespace WebShopApp.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;

        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetClientsCount() => _context.Users.Count() - 1;

        public int GetOrdersCount() => _context.Orders.Count();

        public int GetProductsCount() => _context.Products.Count();

        public decimal GetOrdersSum() => _context.Orders.ToList().Sum(x => x.TotalPrice);
    }
}
