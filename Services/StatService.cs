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
        PlayerChartModel playerChartModel = new() { Id = player.Id, Name = player.Name, StatList = new() };

        var stats = await _statRepository.GetPlayerStatsInGame(player, game);
        var statTypes = Enum.GetValues(typeof(StatType));


        playerChartModel.StatList = stats.GroupBy(x => x.Stat).
                                         Select(m => new StatChartModel { Type = m.Key, Count = m.Count() }).
                                         ToList();

        return playerChartModel;
    }

    public async Task<SeasonDataModel> GetPlayerSeasonData(Player player)
    {
        var allStats = await _statRepository.GetPlayerStats(player);
        var shotList = allStats.Where(x => x.Stat == StatType.Shot).ToList();
        var passList = allStats.Where(x => x.Stat == StatType.Pass).ToList();
        var blockList = allStats.Where(x => x.Stat == StatType.Block).ToList();
        var interceptionList = allStats.Where(x => x.Stat == StatType.Interception).ToList();
        var reboundList = allStats.Where(x => x.Stat == StatType.Rebound).ToList();

        var shots = shotList.GroupBy(x => x.InGame.DateTime).Select(dateGroup => new ShotModel() { GameDate = dateGroup.Key, Count = dateGroup.Count() }).ToList();
        var passes = passList.GroupBy(x => x.InGame.DateTime).Select(dateGroup => new PassModel() { GameDate = dateGroup.Key, Count = dateGroup.Count() }).ToList();
        var blocks = blockList.GroupBy(x => x.InGame.DateTime).Select(dateGroup => new BlockModel() { GameDate = dateGroup.Key, Count = dateGroup.Count() }).ToList();
        var interceptions = interceptionList.GroupBy(x => x.InGame.DateTime).Select(dateGroup => new InterceptionModel() { GameDate = dateGroup.Key, Count = dateGroup.Count() }).ToList();
        var rebounds = reboundList.GroupBy(x => x.InGame.DateTime).Select(dateGroup => new ReboundModel() { GameDate = dateGroup.Key, Count = dateGroup.Count() }).ToList();

        var seasonData = new SeasonDataModel()
        {
            Blocks = blocks,
            Shots = shots,
            Passes = passes,
            Interceptions = interceptions,
            Rebounds = rebounds
        };

        return seasonData;
    }
}
