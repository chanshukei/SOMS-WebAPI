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
    public class DeliveryAddressesController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public DeliveryAddressesController(SqlServerContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryAddresses
        [HttpGet("{customerNo}")]
        public async Task<ActionResult<IEnumerable<DeliveryAddress>>> GetDeliveryAddress(string customerNo)
        {
            var result = await _context.DeliveryAddress.FromSqlRaw(
                "SELECT CONCAT(Customer_No, '#', Address_ID) AddressId, Address FROM DELIVERY_ADDRESS " +
                "WHERE Customer_No=@CustomerNo", 
                new SqlParameter("CustomerNo", customerNo)).ToListAsync();
            if (result == null || result.Count == 0)
            {
                return NotFound();
            }
            return result;
        }

    }
}
