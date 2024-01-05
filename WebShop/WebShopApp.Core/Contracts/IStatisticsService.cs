using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopApp.Core.Contracts
{
    public interface IStatisticsService
    {
        int GetProductsCount();
        int GetClientsCount();
        int GetOrdersCount();
        decimal GetOrdersSum();
    }
}
