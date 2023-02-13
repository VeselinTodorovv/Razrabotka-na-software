using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Views
{
    class Display
    {
        public Display()
        {
            Distance = 0;
            TimeOfDay = "";
            Price = 0;
            GetValues();
        }
        public int Distance { get; set; }
        public string TimeOfDay { get; set; }
        public double Price { get; set; }
        public void GetValues()
        {
            Console.WriteLine("Enter km:");
            Distance = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter time of day:");
            TimeOfDay = Console.ReadLine();
        }
        public void ShowPrice()
        {
            Console.WriteLine($"The cheapest price is {Price:f2}");
        }
    }
}
