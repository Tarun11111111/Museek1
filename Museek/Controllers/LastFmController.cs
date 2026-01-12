using Microsoft.AspNetCore.Mvc;
using Museek.Services;

namespace Museek.Controllers
{
    [ApiController]
    [Route("api/lastfm")]
    public class LastFmController : ControllerBase
    {
        private readonly LastFmClient _client;

        public LastFmController(LastFmClient client)
        {
            _client = client;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<string>>> Search([FromQuery] string query)
        {
            var list = await _client.SearchArtistsAsync(query, limit: 8);
            return Ok(list);
        }

        [HttpGet("artist")]
        public async Task<ActionResult<object>> Artist([FromQuery] string name)
        {
            var info = await _client.GetArtistInfoAsync(name);
            if (info == null) return NotFound();

            return Ok(new
            {
                name = info.Name,
                bio = info.Bio
            });
        }
    }
}
