using Games.API.Models;
using Games.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Games.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class GamesController : ControllerBase
{

    private readonly IGameRepository _gameRepository;

    public GamesController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Game>))]
    public async Task<IActionResult> Get()
    {
        var games = await _gameRepository.GetGamesAsync();

        return Ok(games);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Game>)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string id)
    {
        var game = await _gameRepository.GetByIdAsync(id);

        if (game is null)
            return NotFound();

        return Ok(game);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] Game game)
    {
        await _gameRepository.AddGameAsync(game);

        return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(string id, [FromBody] Game game)
    {

        var gameDetail = await _gameRepository.GetByIdAsync(id);

        if (gameDetail is null)
            return NotFound();

        game.Id = gameDetail.Id;

        await _gameRepository.UpdateGameAsync(id, game);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var gameDetail = await _gameRepository.GetByIdAsync(id);

        if (gameDetail is null)
            return NotFound();

        await _gameRepository.DeleteGameAsync(id);

        return NoContent();
    }
}
