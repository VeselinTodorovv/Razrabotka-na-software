using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonApp
{
    static class Program
    {
        static void Main() {
            List<Product> productsList = new List<Product>() {
                new(1, "Milk", 2.59m, 100, new DateTime(2019, 06, 30)),
                new(2, "Lyutenica", 2.39m, 100, new DateTime(2019, 08, 30)),
                new(3, "Rice", 1.50m, 100, new DateTime(2020, 03, 30)),
                new(4, "Salt", 100.01M, 100, new DateTime(2019, 10, 30))
            };
            string jsonList = JsonConvert.SerializeObject(productsList);
            Console.WriteLine($"Lists of products:\n{jsonList}");
            Console.WriteLine(new string('-', 50));

            string jsonSizes = @"['Small', 'Medium', 'Large']";
            JArray a = JArray.Parse(jsonSizes);
            foreach (var token in a) {
                Console.WriteLine(token);
            }
        }
    }
}