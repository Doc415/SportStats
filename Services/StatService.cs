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
        PlayerChartModel playerChartModel = new() { Id = player.Id, Name = player.Name };

        var stats = await _statRepository.GetPlayerStatsInGame(player, game);

        StatChartModel pass = new StatChartModel()
        {
            Type = Enums.StatType.Pass,
            Count = stats.Count(x => x.Stat == Enums.StatType.Pass)
        };

        StatChartModel shot = new StatChartModel()
        {
            Type = Enums.StatType.Shot,
            Count = stats.Count(x => x.Stat == Enums.StatType.Shot)
        };

        StatChartModel rebound = new StatChartModel()
        {
            Type = Enums.StatType.Rebound,
            Count = stats.Count(x => x.Stat == Enums.StatType.Rebound)
        };

        StatChartModel block = new StatChartModel()
        {
            Type = Enums.StatType.Block,
            Count = stats.Count(x => x.Stat == Enums.StatType.Block)
        };

        StatChartModel interception = new StatChartModel()
        {
            Type = Enums.StatType.Interception,
            Count = stats.Count(x => x.Stat == Enums.StatType.Interception)
        };

        playerChartModel.StatList.Add(pass);
        playerChartModel.StatList.Add(shot);
        playerChartModel.StatList.Add(interception);
        playerChartModel.StatList.Add(block);
        playerChartModel.StatList.Add(rebound);

        return playerChartModel;
    }
}
