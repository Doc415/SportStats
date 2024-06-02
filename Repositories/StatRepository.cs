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
}
