using ConsoleApp1.Model;
using ConsoleApp1.Views;

namespace ConsoleApp1.Controllers;

public class VegetableController
{
    public VegetableController()
    {
        Display display = new Display();
        Vegetable vegetable = new Vegetable(display.VegetablePrice, display.FruitPrice, display.VegetableTotal,
            display.FruitTotal);
        display.Total = vegetable.CalculatePrice();
        display.ShowResult();
    }
}