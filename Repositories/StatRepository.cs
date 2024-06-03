using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;

namespace SportStats.Repositories;

public class StatRepository : IStatRepository
{
    public StatsContext _context;

    public StatRepository(StatsContext context)
    {
        _context = context;
    }

    public async Task AddStat(BaseStat newStat)
    {
        await _context.Stats.AddAsync(newStat);
        await _context.SaveChangesAsync();
    }

    public async Task<List<BaseStat>> GetPlayerStatsInGame(Player player, Game game)
    {
        try
        {
            var statList= await _context.Stats.Where(s=> s.InGame == game && s.BelongsTo==player).ToListAsync();
            return statList;
        }
        catch(Exception e)
        {
            Console.Error.WriteLine(e.Message);
            return null;
        }
    }
}
