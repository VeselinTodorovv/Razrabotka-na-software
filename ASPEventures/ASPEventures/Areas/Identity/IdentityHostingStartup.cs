using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ASPEventures.Areas.Identity.IdentityHostingStartup))]
namespace ASPEventures.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}