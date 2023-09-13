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
using pp_test.Controllers;

namespace pp_test.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostamatController : ControllerBase
    {

        private readonly PPTestContext _db;
        private readonly ILogger<OrderController> _logger;
        private readonly CRUD.Postamat pst;


        public PostamatController(ILogger<OrderController> logger, PPTestContext context)
        {
            _logger = logger;
            _db = context;
            pst = new CRUD.Postamat(logger, context);
        }

        [HttpGet]
        public async Task<ActionResult<IPostamat>> GetPostamatById(string id)
        {
            return Ok(await pst.ReadById(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IPostamat>>> GetAllPostamats()
        {
            return Ok(await pst.Read());
        }

    }
}
