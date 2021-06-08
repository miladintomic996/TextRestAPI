using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreRepositoryAndUnitOfWorkPattern.Data.Models;
using NetCoreRepositoryAndUnitOfWorkPattern.Service.Services;

namespace TextRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbTextController : ControllerBase
    {

        private readonly IDbTextService _dbTextService;
        private readonly ILogger _logger;


        public DbTextController(IDbTextService dbTextService, ILogger<DbTextController> logger)
        {
            this._dbTextService = dbTextService;
            this._logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetFromDb(int id)
        {
            try
            {
                return Ok(_dbTextService.GetAllTextsAsync().Result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NoContent();
            }
        }
    }
}
