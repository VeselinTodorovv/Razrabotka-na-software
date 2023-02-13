using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMVC.Model
{
    public class Tip
    {
        public double Amount { get; set; }
        private double percent;

        public Tip(double amount, double percent)
        {
            Amount = amount;
            Percent = percent;
        }
        public Tip() : this(0, 0) { }

        public double Percent
        {
            get { return this.percent; }
            set
            {
                if (value > 1)
                {
                    this.percent = value / 100;
                }
                else
                {
                    this.percent = value;
                }
            }
        }
        public double CalculateTip()
        {
            return Amount * Percent;
        }
        public double CalculateTotal()
        {
            return CalculateTip() + Amount;
        }
    }
}
