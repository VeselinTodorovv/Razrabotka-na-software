namespace ConsoleApp1.Model;

public class Vegetable
{
    private double VegetablePrice { get; }
    private double FruitPrice { get; }
    private int VegetableTotal { get; }
    private int FruitTotal { get; }

    public Vegetable(double vegetablePrice, double fruitPrice, int vegetableTotal, int fruitTotal) {
        VegetablePrice = vegetablePrice;
        FruitPrice = fruitPrice;
        VegetableTotal = vegetableTotal;
        FruitTotal = fruitTotal;
    }
    public Vegetable() : this(0, 0, 0, 0) {}

    public double CalculatePrice() {
        return (VegetablePrice * VegetableTotal + FruitPrice * FruitTotal) / 1.94;
    }
}