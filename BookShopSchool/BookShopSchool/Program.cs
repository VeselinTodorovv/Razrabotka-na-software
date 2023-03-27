using BookShopSchool.Data;

namespace BookShopSchool
{
    static class Program
    {
        static void Main() {
            var context = new BookShopSchoolContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}