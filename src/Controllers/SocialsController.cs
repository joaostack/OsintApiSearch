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
        private readonly IChessService _chessService;
        private readonly IDuoService _duoService;

        public SocialsController(
            IPicsartService picsartService,
            INetShoesService netshoesService,
            IXwitterService xwitterService,
            ISpotifyService spotifyService,
            IChessService chessService,
            IDuoService duoService
        )
        {
            _picsartService = picsartService;
            _netshoesService = netshoesService;
            _xwitterService = xwitterService;
            _spotifyService = spotifyService;
            _chessService = chessService;
            _duoService = duoService;
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

        [HttpGet("chess")]
        public async Task<IActionResult> ChessCheck(string email)
        {
            try
            {
                var exists = await _chessService.MailExistsAsync(email);
                return Ok(new { exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("duolingo")]
        public async Task<IActionResult> DuoCheck(string email)
        {
            try
            {
                var exists = await _duoService.MailExistsAsync(email);
                return Ok(new { exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("checkAll")]
        public async Task<IActionResult> CheckAll(string email)
        {
            try
            {
                var chessExists = await _chessService.MailExistsAsync(email);
                var xwitterExists = await _xwitterService.MailExistsAsync(email);
                var picsartExists = await _picsartService.MailExistsAsync(email);
                var netshoesExists = await _netshoesService.MailExistsAsync(email);
                var spotifyExists = await _spotifyService.MailExistsAsync(email);
                var duoExists = await _duoService.MailExistsAsync(email);

                var exists = new Dictionary<string, bool>()
                {
                    { "Chess", chessExists },
                    { "Picsart", picsartExists },
                    { "Xwitter", xwitterExists },
                    { "Spotify", spotifyExists },
                    { "Netshoes", netshoesExists },
                    { "Duolingo", duoExists },
                };

                if (exists == null)
                {
                    return NotFound("Not results found");
                }

                return Ok(new { exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
