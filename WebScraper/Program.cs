using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebScraper.Data;
using WebScraper.Interfaces;
using WebScraper.Repositories;
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
        builder.Services.AddScoped<IBasketballGameRepository, BasketballGameRepository>();
        builder.Services.AddScoped<IEmailService, BasketballEmailService>();

        IHost app = builder.Build();

        var _context = app.Services.GetRequiredService<WebScraperContext>();

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        app.RunAsync();

        var _controller = app.Services.GetRequiredService<DailyReportController>();

        _controller.ExecuteDailyReportService();

        app.StopAsync();
    }
}
