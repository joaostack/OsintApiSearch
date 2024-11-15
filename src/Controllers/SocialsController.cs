using Microsoft.AspNetCore.Mvc;

namespace OsintApiSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SocialsController : ControllerBase
    {
        private readonly IPicsartService _picsartService;
        private readonly INetShoesService _netshoesService;
        private readonly IXwitterService _xwitterService;
        private readonly ISpotifyService _spotifyService;

        public SocialsController(
            IPicsartService picsartService,
            INetShoesService netshoesService,
            IXwitterService xwitterService,
            ISpotifyService spotifyService
        )
        {
            _picsartService = picsartService;
            _netshoesService = netshoesService;
            _xwitterService = xwitterService;
            _spotifyService = spotifyService;
        }

        [HttpGet("picsart")]
        public async Task<IActionResult> PicsartCheck(string email)
        {
            try
            {
                var exists = await _picsartService.MailExistsAsync(email);
                return Ok(new { exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("netshoes")]
        public async Task<IActionResult> NetShoesCheck(string email)
        {
            try
            {
                var exists = await _netshoesService.MailExistsAsync(email);
                return Ok(new { exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("xwitter")]
        public async Task<IActionResult> XwitterCheck(string email)
        {
            try
            {
                var exists = await _xwitterService.MailExistsAsync(email);
                return Ok(new { exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("spotify")]
        public async Task<IActionResult> SpotifyCheck(string email)
        {
            try
            {
                var exists = await _spotifyService.MailExistsAsync(email);
                return Ok(new { exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
