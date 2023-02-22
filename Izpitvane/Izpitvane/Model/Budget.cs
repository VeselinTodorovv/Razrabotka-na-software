using System;

namespace Izpitvane.Model {
    public class Budget {
        private double Money {
            get => _money;
            set {
                if (value is < 10 or > 5000) {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _money = value;
            }
        }
        private double _money;

        private string Season {
            get => _season;
            init {
                if (value != "summer" && value != "winter") {
                    throw new ArgumentException("invalid season");
                }
                _season = value;
            }
        }
        private readonly string _season;
        
        private string Destination { get; set; }
        public Budget(double money, string season) {
            Money = money;
            Season = season;
        }
        public Budget() : this(0, "") {}

        public double Calculation() {
            Money = Money switch {
                <= 100 when Season == "summer" => Money / 100 * 30,
                <= 100 when Season == "winter" => Money / 100 * 70,
                
                <= 1000 when Season == "summer" => Money / 100 * 40,
                <= 1000 when Season == "winter" => Money / 100 * 80,
                
                _ => Money / 100 * 90
            };
            return Money;
        }
        
        public string DetermineDestination() {
            Destination = Money switch {
                <= 100 => "Bulgaria",
                <= 1000 => "Balkans",
                _ => "Europe"
            };
            return Destination;
        }
        public string DetermineHolidayType() {
            string holidayType;
            if (Season == "summer" && Destination != "Europe")
                holidayType = "Camp";
            else
                holidayType = "Hotel";

            return holidayType;
        }
    }
}