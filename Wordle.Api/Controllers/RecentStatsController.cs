using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecentStatsController : ControllerBase
{

    private readonly RecentStatsService _service;
    public RecentStatsController(RecentStatsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<RecentStats> Get([FromBody] int playerId)
    {
        return _service.GetRecentScoreStats(playerId);

    }
}
