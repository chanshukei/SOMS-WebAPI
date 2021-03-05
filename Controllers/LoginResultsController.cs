using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SOMS_WebAPI.Models;
using SOMS_WebAPI.Models.Context;

namespace SOMS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginResultsController : ControllerBase
    {
        private readonly LoginResultContext _context;

        public LoginResultsController(LoginResultContext context)
        {
            _context = context;
        }

        // GET: api/LoginResults/Bobby Ho/P@ssw0rd
        [HttpGet("{userId}/{password}")]
        public async Task<ActionResult<IEnumerable<LoginResult>>> GetLoginResult(string userId, string password)
        {
            //Use store procedure because the sql is complex and store procedure has better performance than complied LINQ
            var loginResult = await _context.LoginResults
                .FromSqlRaw("EXEC GetLoginResult @UserId, @Password",
                new SqlParameter("UserId", userId),
                new SqlParameter("Password", password)).ToListAsync();
            if (loginResult == null)
            {
                return NotFound();
            }
            return loginResult;
        }



    }
}
