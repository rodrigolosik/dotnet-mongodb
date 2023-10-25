using Games.API.Models;

namespace Games.API.Repositories;

public interface IGameRepository
{
    Task<Game> GetByIdAsync(string id);
    Task<IEnumerable<Game>> GetGamesAsync();
    Task AddGameAsync(Game game);
    Task UpdateGameAsync(string id, Game game);
    Task DeleteGameAsync(string id);
}
