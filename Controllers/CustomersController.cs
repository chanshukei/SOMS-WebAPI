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
    public class CustomersController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public CustomersController(SqlServerContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(string userId)
        {
            var result = await _context.Customer.FromSqlRaw(
                "SELECT Customer_No CustomerNo, English_Name EnglishName FROM Customer C " +
                "WHERE EXISTS (" +
                "SELECT 1 FROM Salesman_Access SA " +
                "WHERE SA.User_ID=@UserId AND C.Salesman_ID=SA.Salesman_ID" +
                ")",
                new SqlParameter("UserId", userId)).ToListAsync();
            if (result == null || result.Count == 0)
            {
                return NotFound();
            }
            return result;
        }


    }
}
