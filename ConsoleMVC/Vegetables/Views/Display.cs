using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Views;

public class Display
{
    public Display()
    {
        VegetablePrice = 0;
        FruitPrice = 0;
        VegetableTotal = 0;
        FruitTotal = 0;
        Total = 0;
        GetValues();
    }
    
    [Range(1, 1000)]
    public double VegetablePrice { get; private set; }
    [Range(1, 1000)]
    public double FruitPrice { get; private set; }
    [Range(1, 1000)]
    public int VegetableTotal { get; private set; }
    [Range(1, 1000)]
    public int FruitTotal { get; private set; }
    public double Total { get; set; }

    private void GetValues()
    {
        Console.WriteLine("Enter vegetables price:");
        VegetablePrice = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter fruits price:");
        FruitPrice = double.Parse(Console.ReadLine()!);
        
        Console.WriteLine("Enter vegetables kg:");
        VegetableTotal = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter fruits kg:");
        FruitTotal = int.Parse(Console.ReadLine()!);
    }

    public void ShowResult()
    {
        Console.WriteLine(Total);
    }
}