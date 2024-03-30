namespace WebScraper.Models;

public class BasketballGameDTO
{
    public string HomeTeam { get; set; } = null!;

    public string AwayTeam { get; set; } = null!;

    public int HomeTeamScore { get; set; }

    public int AwayTeamScore { get; set; }
}
