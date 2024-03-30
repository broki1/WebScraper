using HtmlAgilityPack;
using WebScraper.Models;

namespace WebScraper.Interfaces;

internal interface IWebScraperService
{
    public string GetHeader();
    public string GetNumGamesPlayed();

    public List<BasketballGameDTO> GetTeamsAndScores();
}
