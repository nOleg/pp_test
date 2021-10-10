//Получение списка рабочих постаматов, отсортированных по номеру в алфавитном порядке
//Получение информации о постамат

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pp_test;

namespace pp_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostamatController : ControllerBase
    {

        PPTestContext db = new PPTestContext();
        private readonly ILogger<OrderController> _logger;

        public PostamatController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

     
    [HttpGet("get")]
        public async Task<Postamat> Get(string id)
        {
            return await db.Postamats
                .Where(or=>or.Num==id)
                .FirstAsync();
        }
    [HttpGet("all")]
        public async Task<IEnumerable<Postamat>> Get()
        {
            return await db.Postamats
            .Where(ps=>ps.Status==true)
            .OrderBy(s=>s.Num).ToArrayAsync();
                
        }

    }
}
