using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Model
{
    public class TransportModel
    {
        public int Distance { get; set; }
        public string TimeOfDay { get; set; }

        public TransportModel(int distance, string timeofday)
        {
            Distance = distance;
            TimeOfDay = timeofday;
        }

        public TransportModel() : this(0, "") { }
        public double CalculatePrice()
        {
            double taksa = 0;
            double tarifa = 0;
            if (Distance < 20)
            {
                taksa = 0.70;
                if (TimeOfDay == "day")
                {
                    tarifa = 0.79;
                }
                else if (TimeOfDay == "night")
                {
                    tarifa = 0.9;
                }
            }
            else if (Distance < 100)
            {
                tarifa = 0.09;
            }
            else
            {
                tarifa = 0.06;
            }
            return taksa + tarifa * Distance;
        }
    }
}
