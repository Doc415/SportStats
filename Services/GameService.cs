using SportStats.Models;
using SportStats.Repositories;

namespace SportStats.Services;

public class GameService
{
    IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    public async Task<Game> AddGame(Game game)
    { return await _gameRepository.AddGame(game); }
}
