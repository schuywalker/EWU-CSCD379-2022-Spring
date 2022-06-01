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

    [HttpPost]
    public IEnumerable<RecentStats> Post([FromBody] PlayerGuid player)
    {
        var list = _service.GetRecentScoreStats(player.Guid);
        return list;
    }
    public class PlayerGuid
    {
        public Guid Guid { get; set; }
    }
}
