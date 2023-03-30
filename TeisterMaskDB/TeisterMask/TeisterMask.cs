using System;
using TeisterMask.Data;

namespace TeisterMask
{
    static class Program
    {
        static void Main() {
            var context = new TeisterMaskContext();

            context.Database.EnsureCreated();
        }
    }
}