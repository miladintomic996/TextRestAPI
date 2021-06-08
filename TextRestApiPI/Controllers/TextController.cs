using Microsoft.AspNetCore.Mvc;
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
        public TextResponse Post([FromBody] string text)
        {
            return textService.CountWords(text);
        }

        [HttpGet("db/{id}")]
        public TextResponse GetFromDb(int id)
        {
            return textService.CountWordsDb(id).Result;
        }

        [HttpGet("file/{filename}")]
        public TextResponse GetFromFile(string filename)
        {
            return textService.CountWordsFile(filename);
        }
    }
}
