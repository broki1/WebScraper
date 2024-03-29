using HtmlAgilityPack;

namespace WebScraper.Interfaces;

internal interface IWebScraperService
{
    public string GetHeader();
    public string GetNumGamesPlayed();

    public void GetGamesPlayed();
}
