using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebScraper.Data;

namespace WebScraper;

internal class Program
{
    static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddDbContext<WebScraperContext>();

        IHost app = builder.Build();

        var _context = app.Services.GetRequiredService<WebScraperContext>();

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        app.RunAsync();
    }
}
