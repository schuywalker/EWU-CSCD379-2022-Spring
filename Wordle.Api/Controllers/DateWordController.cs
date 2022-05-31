using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;
using static Wordle.Api.Data.Game;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DateWordController : Controller
{
    private readonly GameService _gameService;


    public DateWordController(GameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost]
    [Route("[action]")]
    public GameDto CreateGame([FromBody] CreateGameDto newGame)
    {
        var game = _gameService.CreateGame(new Guid(newGame.PlayerGuid), GameTypeEnum.WordOfTheDay, newGame.Date);
        return new GameDto(game);
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult FinishGame([FromBody] FinishGameDto finishedGame)
    {
        _gameService.FinishGame(finishedGame.GameId, finishedGame.PlayerGuid, finishedGame.Seconds, finishedGame.Attempts);
        return Ok();
    }

    public class CreateGameDto
    {
        public DateTime? Date { get; set; }
        public string PlayerGuid { get; set; } = null!;
    }

    public class FinishGameDto
    {
        public int GameId { get; set; }
        public Guid PlayerGuid { get; set; }
        public int Seconds { get; set; }
        public int Attempts { get; set; }
    }
}

internal record struct NewStruct(object Item1, object Item2)
{
    public static implicit operator (object, object)(NewStruct value)
    {
        return (value.Item1, value.Item2);
    }

    public static implicit operator NewStruct((object, object) value)
    {
        return new NewStruct(value.Item1, value.Item2);
    }
}
