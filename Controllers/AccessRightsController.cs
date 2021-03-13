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
    public class AccessRightsController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public AccessRightsController(SqlServerContext context)
        {
            _context = context;
            // for read only, no track changes needed
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // GET: api/AccessRights/PlaceOrder/create/BOBBY HO
        [HttpGet("{functionId}/{mode}/{userId}")]
        public async Task<ActionResult<IEnumerable<AccessRight>>> GetAccessRight(string userId, string functionId, string mode)
        {
            //Use store procedure because the sql is complex and store procedure has better performance than complied LINQ
            var accessRight = await _context.AccessRights
                .FromSqlRaw("EXEC GetAccessRights @UserId, @FunctionId, @Mode", 
                new SqlParameter("UserId", userId), 
                new SqlParameter("FunctionId", functionId),
                new SqlParameter("Mode", mode)).ToListAsync();
            if (accessRight == null || accessRight.Count==0)
            {
                return NotFound();
            }
            return accessRight;
        }

    }
}
