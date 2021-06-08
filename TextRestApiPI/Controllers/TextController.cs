using Microsoft.AspNetCore.Mvc;
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
        private readonly ITextService textService;

        public TextController(ITextService textService)
        {
            this.textService = textService;
        }

        [HttpPost]
        [Consumes("text/plain")]
        public async Task<IActionResult> Post([FromBody] string text)
        {
            try
            {
                return Ok(textService.CountWords(text));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NoContent();
            }

        }

        [HttpGet("db/{id}")]
        public async Task<IActionResult> GetFromDb(int id)
        {
            try
            {
                return Ok(textService.CountWordsDb(id).Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NoContent();
            }

        }

        [HttpGet("file/{filename}")]
        public async Task<IActionResult> GetFromFile(string filename)
        {
            try
            {
                return Ok(textService.CountWordsFile(filename));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NoContent();
            }
        }
    }
}
