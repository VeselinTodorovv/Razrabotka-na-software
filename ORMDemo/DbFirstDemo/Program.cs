using System;
using DbFirstDemo.Data.Models;
using static DbFirstDemo.Operations;

namespace DbFirstDemo
{
    static class Program
    {
        static void Main() {
            var context = new SoftUniContext();
            Console.WriteLine(GetEmployeesWorkingOnClassicVest(context));
        }
    }
}