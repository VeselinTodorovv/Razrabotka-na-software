using Izpitvane.Model;
using Izpitvane.View;

namespace Izpitvane.Controller {
    public class BudgetController {
        public BudgetController() {
            var display = new Display();
            var budget = new Budget(display.Money, display.Season);
            display.Money = budget.Calculation();
            display.Destination = budget.DetermineDestination();
            display.HolidayType = budget.DetermineHolidayType();
            display.Output();
        }
    }
}