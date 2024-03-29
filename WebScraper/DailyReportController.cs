using WebScraper.Interfaces;

namespace WebScraper;

internal class DailyReportController
{

    private readonly IWebScraperService _service;

    DailyReportController(IWebScraperService service)
    {
        _service = service;
    }

    internal void SendDailyReport()
    {
        var header = this._service.GetHeader();
        var body = this._service.GetNumGamesPlayed();
    }
}
