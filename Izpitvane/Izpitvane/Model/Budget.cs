using System;

namespace Izpitvane.Model
{
    public class Budget
    {
        private double Money
        {
            get => _money;
            set
            {
                if (value is < 10 or > 5000) 
                {
                    throw new ArgumentOutOfRangeException($"invalid money");
                }
                _money = value;
            }
        }
        private double _money;

        private string Season
        {
            get => _season;
            set
            {
                if (value != "summer" && value != "winter")
                {
                    throw new ArgumentException("invalid season");
                }
                _season = value;
            }
        }
        private string _season;
        public Budget(double money, string season)
        {
            Money = money;
            Season = season;
        }
        public Budget() : this(0, "") {}

        public double Calculation()
        {
            switch (Money)
            {
                case <= 100 when Season == "summer":
                    Money = Money / 100 * 30;
                    break;
                case <= 100:
                {
                    if (Season == "winter")
                    {
                        Money = Money / 100 * 70;
                    }

                    break;
                }
                case <= 1000 when Season == "summer":
                    Money = Money / 100 * 40;
                    break;
                case <= 1000:
                {
                    if (Season == "winter")
                    {
                        Money = Money / 100 * 80;
                    }

                    break;
                }
                default:
                    Money = Money / 100 * 90;
                    break;
            }

            return Money;
        }
    }
}