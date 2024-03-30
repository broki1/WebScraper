using HtmlAgilityPack;
using WebScraper.Data;
using WebScraper.Interfaces;
using WebScraper.Models;

namespace WebScraper.Services;

public class BasketballScraperService : IWebScraperService
{
    private readonly WebScraperContext _context;
    private readonly string _url;
    private HtmlWeb _web;
    private HtmlDocument _document;

    public BasketballScraperService(WebScraperContext context)
    {
        this._context = context;
        this._url = "https://www.basketball-reference.com/boxscores/";
        this._web = new HtmlWeb();
        this._document = this._web.Load(this._url);
    }

    public string GetHeader()
    {
        var node = this._document.DocumentNode.SelectSingleNode("//html//body//div[@id='wrap']//div[@id='content']//h1");
        return node.InnerText;
    }

    public string GetNumGamesPlayed()
    {
        var node = this._document.DocumentNode.SelectSingleNode("//html//body//div[@id='wrap']//div[@id='content']//div[@class='section_heading']//h2");
        return node.InnerText;
    }

    public List<BasketballGameDTO> GetTeamsAndScores()
    {
        var games = this._document.DocumentNode.SelectNodes("//div[@class='game_summary expanded nohover ']").ToArray();
        var basketballGames = new List<BasketballGameDTO>();

        foreach (var game in games)
        {
            var awayTeam = game.SelectSingleNode("table[@class='teams']//tbody//tr[1]//td[1]//a").InnerText;
            var homeTeam = game.SelectSingleNode("table[@class='teams']//tbody//tr[2]//td[1]//a").InnerText;

            var awayScore = Convert.ToInt32(game.SelectSingleNode("table[@class='teams']//tbody//tr[1]//td[2]").InnerText);
            var homeScore = Convert.ToInt32(game.SelectSingleNode("table[@class='teams']//tbody//tr[2]//td[2]").InnerText);



            var basketballGame = new BasketballGameDTO
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                HomeTeamScore = homeScore,
                AwayTeamScore = awayScore
            };

            basketballGames.Add(basketballGame);
            // Console.WriteLine(game.InnerHtml);
        }

        return basketballGames;
    }
}
