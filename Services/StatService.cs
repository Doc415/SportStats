using SportStats.Enums;
using SportStats.Models;
using SportStats.Repositories;

namespace SportStats.Services;

public class StatService
{
    public IStatRepository _statRepository;

    public StatService(IStatRepository statRepository)
    {
        _statRepository = statRepository;
    }

    public async Task AddStat(BaseStat newStat)
    {
        await _statRepository.AddStat(newStat);
    }

    public async Task<PlayerChartModel> GetPlayerStatsInGameForChart(Player player, Game game)
    {
        PlayerChartModel playerChartModel = new() { Id = player.Id, Name = player.Name , StatList=new()};
        var stats = await _statRepository.GetPlayerStatsInGame(player, game);
        var statTypes = Enum.GetValues(typeof(StatType));

       
       

        playerChartModel.StatList= stats.GroupBy(x=> x.Stat).
                                         Select(m=> new StatChartModel { Type=m.Key,Count=m.Count()}).
                                        ToList();

        return playerChartModel;
    }
}
