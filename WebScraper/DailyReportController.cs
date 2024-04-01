using WebScraper.Data;
using WebScraper.Interfaces;

namespace WebScraper;

public class DailyReportController
{
    private readonly IWebScraperService _service;
    private readonly WebScraperContext _context;
    private readonly IEmailService _emailService;

    public DailyReportController(IWebScraperService service, WebScraperContext context, IEmailService emailService)
    {
        this._service = service;
        this._context = context;
        this._emailService = emailService;
    }

    internal void ExecuteDailyReportService()
    {
        try
        {
            this._service.InsertGames();

            var games = this._context.BasketballGames.ToList();

            var emailBody = this._emailService.CreateBody(games);

            var email = this._emailService.CreateEmail(emailBody);

            this._emailService.SendEmail(email);
        }

        catch (ArgumentNullException ex)
        {
            var email = this._emailService.CreateEmail("No games were played today.");

            this._emailService.SendEmail(email);
        }
    }
}
