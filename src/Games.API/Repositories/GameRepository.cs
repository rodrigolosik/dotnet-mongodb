using Games.API.Models;
using MongoDB.Driver;

namespace Games.API.Repositories;

public class GameRepository : IGameRepository
{
    private readonly IMongoCollection<Game> _collection;
    private const string CollectionName = "games";

    public GameRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Game>(CollectionName);
    }

    public async Task<IEnumerable<Game>> GetGamesAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task AddGameAsync(Game game) =>
        await _collection.InsertOneAsync(game);

    public async Task<Game> GetByIdAsync(string id) =>
        await _collection.FindSync(game => game.Id == id).FirstOrDefaultAsync();

    public async Task UpdateGameAsync(string id, Game game) =>
        await _collection.ReplaceOneAsync(game => game.Id == id, game);

    public async Task DeleteGameAsync(string id) =>
        await _collection.DeleteOneAsync(game => game.Id == id);
}