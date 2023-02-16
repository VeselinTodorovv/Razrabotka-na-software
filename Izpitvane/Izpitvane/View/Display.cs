using System;

namespace Izpitvane.View
{
    public class Display
    {
        public double Money { get; set; }
        public string Season { get; private set; }
        private string Destination { get; set; }

        public Display()
        {
            Money = 0;
            Season = "";
            Input();
        }

        private void Input()
        {
            Money = double.Parse(Console.ReadLine()!);
            Season = Console.ReadLine();
        }

        public void Output()
        {
            Console.WriteLine($"Somewhere in {DetermineDestination()}");
            Console.WriteLine($"{DetermineHolidayType()} - {Money:f2}");
        }

        private string DetermineDestination()
        {
            Destination = Money switch
            {
                <= 100 => "Bulgaria",
                <= 1000 => "Balkans",
                _ => "Europe"
            };
            return Destination;
        }

        private string DetermineHolidayType()
        {
            string holidayType;
            if (Season == "summer" && Destination != "Europe")
                holidayType = "Camp";
            else
                holidayType = "Hotel";

            return holidayType;
        }
    }
}