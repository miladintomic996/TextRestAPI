using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreRepositoryAndUnitOfWorkPattern.Data.Models;
using NetCoreRepositoryAndUnitOfWorkPattern.Service.Services;

namespace TextRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbTextController : ControllerBase
    {

        private readonly IDbTextService _dbTextService;

        public DbTextController(IDbTextService dbTextService)
        {
            this._dbTextService = dbTextService;
        }

        [HttpGet("all")]
        public async Task<List<Text>> GetFromDb(int id)
        {
            return _dbTextService.GetAllTextsAsync().Result;
        }
    }
}
