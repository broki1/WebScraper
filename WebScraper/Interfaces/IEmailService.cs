using WebScraper.Models;

namespace WebScraper.Interfaces;

public interface IEmailService
{
    public string CreateBody(List<BasketballGame> games);
}
