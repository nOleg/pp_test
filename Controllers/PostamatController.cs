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
    [Route("[controller]/[action]")]
    public class PostamatController : ControllerBase
    {
 
        private readonly PPTestContext db;
        private readonly ILogger<OrderController> _logger;

        public PostamatController(ILogger<OrderController> logger,PPTestContext context)
        {
            _logger = logger;
            db = context;
        }

     
    [HttpGet]
        public async Task<ActionResult<IPostamat>> GetPostamatById(string id)
        {
            return await db.Postamats!
                .Where(or=>or.Num==id)
                .FirstAsync();
        }
    [HttpGet]
        public async Task<ActionResult<IEnumerable<IPostamat>>> GetAllPostamats()
        {
            return Ok(await db.Postamats!
            .Where(ps=>ps.Status==true)
            .OrderBy(s=>s.Num).ToArrayAsync());
                
        }

    }
}
