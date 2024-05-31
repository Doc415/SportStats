using SportStats.Models;
using SportStats.Data;

namespace SportStats.Repositories;

public class GameRepository:IGameRepository
{
    public StatsContext _context;

    public GameRepository(StatsContext context)
    {
        _context = context;
    }

        public async Task<Game> AddGame(Game game)
    {
        try
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            var recordedGame = _context.Games.OrderByDescending(e => e.Id).FirstOrDefault();
            return recordedGame;
        } 
        catch (Exception ex)
        {
            return null;
        }
    }
}
