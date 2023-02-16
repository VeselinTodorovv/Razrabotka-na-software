using System;

namespace Izpitvane.View {
    public class Display {
        public double Money { get; set; }
        public string Season { get; private set; }
        public string Destination { get; set; }
        public string HolidayType { get; set; }

        public Display() {
            Money = 0;
            Season = "";
            Destination = "";
            HolidayType = "";
            Input();
        }

        private void Input() {
            Money = double.Parse(Console.ReadLine()!);
            Season = Console.ReadLine();
        }

        public void Output() {
            Console.WriteLine($"Somewhere in {Destination}");
            Console.WriteLine($"{HolidayType} - {Money:f2}");
        }
    }
}