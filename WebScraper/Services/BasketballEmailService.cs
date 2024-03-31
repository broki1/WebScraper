using WebScraper.Interfaces;
using WebScraper.Models;

namespace WebScraper.Services;

internal class BasketballEmailService : IEmailService
{
    public string CreateBody(List<BasketballGame> games)
    {
        var date = games[0].Date.ToString("MMMM dd, yyyy");
        var header = $"Games played on {date}:\n\n";

        var body = "";

        foreach (var game in games)
        {
            var gameEntry = @$"{game.AwayTeam}: {game.AwayTeamScore}
at 
{game.HomeTeam}: {game.HomeTeamScore}

";

            body += gameEntry;
        }

        return header + body;
    }
}
