using SportStats.Models;

namespace SportStats.Repositories;

public interface IGameRepository
{
    Task<Game> AddGame(Game game);
}
