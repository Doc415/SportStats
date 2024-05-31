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
}
