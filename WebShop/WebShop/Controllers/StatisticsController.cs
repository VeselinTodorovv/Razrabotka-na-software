using Microsoft.AspNetCore.Mvc;

using WebShopApp.Core.Contracts;
using WebShopApp.Models.Statistics;

namespace WebShopApp.Controllers
{
    public class StatisticsController: Controller
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public IActionResult Index() 
        {
            StatisticVM statisticVM = new StatisticVM
            {
                CountClients = _statisticsService.GetClientsCount(),
                CountOrders = _statisticsService.GetOrdersCount(),
                CountProducts = _statisticsService.GetProductsCount(),
                SumOrders = _statisticsService.GetOrdersSum(),
            };

            return View(statisticVM);
        }
    }
}
