using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Model;
using Transport.Views;

namespace Transport.Controllers
{
    class TransportController
    {
        private TransportModel transport;
        private Display display;
        public TransportController()
        {
            display = new Display();
            transport = new TransportModel(display.Distance, display.TimeOfDay);
            display.Price = transport.CalculatePrice();
            display.ShowPrice();
        }
    }
}
