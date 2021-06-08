using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TextRestAPI.Model;
using TextRestAPI.Service;

namespace TextRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : Controller
    {
        private readonly ITextService _textService;
        private readonly ILogger _logger;

        public TextController(ITextService textService, ILogger<TextController> logger)
        {
            this._textService = textService;
            this._logger = logger;
        }

        [HttpPost]
        [Consumes("text/plain")]
        public async Task<IActionResult> Post([FromBody] string text)
        {
            try
            {
                _logger.LogError("test");
                return Ok(_textService.CountWords(text));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NoContent();
            }

        }

        [HttpGet("db/{id}")]
        public async Task<IActionResult> GetFromDb(int id)
        {
            try
            {
                return Ok(_textService.CountWordsDb(id).Result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NoContent();
            }

        }

        [HttpGet("file/{filename}")]
        public async Task<IActionResult> GetFromFile(string filename)
        {
            try
            {
                return Ok(_textService.CountWordsFile(filename));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NoContent();
            }
        }
    }
}
