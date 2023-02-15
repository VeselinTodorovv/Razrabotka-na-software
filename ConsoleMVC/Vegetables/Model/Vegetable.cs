namespace ConsoleApp1.Model;

public class Vegetable
{
    private double VegetablePrice { 
        get => _vegetablePrice;
        set {
            if (value is < 1 or > 1000) {
                throw new ArgumentOutOfRangeException($"Value must be between 1 and 1000");
            }
            _vegetablePrice = value;
        }
    }
    private double _vegetablePrice;
    
    private double FruitPrice { 
        get => _fruitPrice;
        set {
            if (value is < 1 or > 1000) {
                throw new ArgumentOutOfRangeException($"Value must be between 1 and 1000");
            }
            _fruitPrice = value;
        }
    }
    private double _fruitPrice;
    
    private int VegetableTotal { 
        get => _vegetableTotal;
        set {
            if (value is < 1 or > 1000) {
                throw new ArgumentOutOfRangeException($"Value must be between 1 and 1000");
            }
            _vegetableTotal = value;
        }
    }
    private int _vegetableTotal;
    
    private int FruitTotal { 
        get => _fruitTotal;
        set {
            if (value is < 1 or > 1000) {
                throw new ArgumentOutOfRangeException($"Value must be between 1 and 1000");
            }
            _fruitTotal = value;
        }
    }
    private int _fruitTotal;

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