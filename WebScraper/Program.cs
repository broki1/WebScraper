using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebScraper.Data;
using WebScraper.Interfaces;
using WebScraper.Services;

namespace WebScraper;

internal class Program
{
    static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddDbContext<WebScraperContext>();
        builder.Services.AddScoped<IWebScraperService, BasketballScraperService>();
        builder.Services.AddScoped<DailyReportController>();

        IHost app = builder.Build();

        var _context = app.Services.GetRequiredService<WebScraperContext>();

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        var _service = app.Services.GetRequiredService<IWebScraperService>();

        app.RunAsync();

        _service.GetGamesPlayed();


        Console.WriteLine(_service.GetHeader());

        app.StopAsync();
    }
}
