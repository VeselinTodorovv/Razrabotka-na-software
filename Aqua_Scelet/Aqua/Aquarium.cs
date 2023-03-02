using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua
{
    public class Aquarium
    {
        private const int DefaultCapacity = 100;
        public Aquarium(string shape, int capacity = DefaultCapacity)
        {
            this.Shape = shape;
            this.Capacity = capacity;
            this.Fishes = new List<Fish>();
        }
        public string Shape { get; set; }
        public int Capacity { get; set; }
        public List<Fish> Fishes { get; set; }

        public void AddFish(Fish fish)
        {
            if (this.Capacity <= 0)
            {
                throw new InvalidOperationException("Invalid operation");
            }

            this.Fishes.Add(fish);
            this.Capacity = this.Capacity - 1;

            Console.WriteLine(ReportAddFish());


        }

        public string ReportAddFish()
        {
            string report = $"You successfully add a fish!";

            return report;
        }

        public void RemoveFish(string type)
        {
            if (this.Fishes.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation");
            }

            var fishToRemove = this.Fishes.FirstOrDefault(x => x.Type == type);
            if (fishToRemove == null)
            {
                throw new InvalidOperationException("Invalid operation");
            }

            this.Fishes.Remove(fishToRemove);
            this.Capacity = this.Capacity + 1;

            Console.WriteLine(ReportRemoveFish());

        }
        public string ReportRemoveFish()
        {
            string report = $"You successfully remove a fish!";

            return report;
        }

        public void Empty()
        {
            if (this.Fishes.Count == 0)
            {
                throw new InvalidOperationException("Aquarium is empty!");
            }
            this.Fishes.Clear();
            this.Capacity = DefaultCapacity;

        }


    }
}
