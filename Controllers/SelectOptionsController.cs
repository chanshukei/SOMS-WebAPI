using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SOMS_WebAPI.Models;
using SOMS_WebAPI.Models.Context;

namespace SOMS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectOptionsController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public SelectOptionsController(SqlServerContext context)
        {
            _context = context;
        }

        // GET: api/SelectOptions
        [HttpGet("{optionType}/{userId}")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetSelectOptions(
            string userId, string optionType)
        {
            var options = await _context.SelectOptions
                .FromSqlRaw("EXEC GetSelectOptions @UserId, @OptionType",
                new SqlParameter("UserId", userId),
                new SqlParameter("OptionType", optionType)).ToListAsync();
            if (options == null || options.Count == 0)
            {
                return NotFound();
            }
            return options;
        }

    }
}
