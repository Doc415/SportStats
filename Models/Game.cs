namespace SportStats.Models;

public class Game
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public string PlayedAgainst { get; set; }
    public List<BaseStat> StatsInGame { get; set; }

}
