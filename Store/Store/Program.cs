using Store.Data;

namespace Store
{
    static class Program
    {
        static void Main() {
            var context = new StoreContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}