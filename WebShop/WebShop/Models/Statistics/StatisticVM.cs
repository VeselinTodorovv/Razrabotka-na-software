using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Models.Statistics
{
    public class StatisticVM
    {
        [Display(Name = "Count users")]
        public int CountClients { get; set; }

        [Display(Name = "Count Products")]
        public int CountProducts { get; set; }

        [Display(Name = "Count Orders")]
        public int CountOrders { get; set; }

        [Display(Name = "Sum Orders")]
        public decimal SumOrders { get; set; }
    }
}
