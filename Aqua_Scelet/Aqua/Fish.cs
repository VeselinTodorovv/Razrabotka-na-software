using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua
{
   public class Fish
    {
        public Fish(string type, decimal price)
        {
            this.Type = type;
            this.Price = price;
           
        }

        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
