using StudentSystem.Data;

namespace StudentSystem
{
    static class Program
    {
        static void Main() {
            StudentSystemContext context = new();
            context.Database.EnsureCreated();
        }
    }
}