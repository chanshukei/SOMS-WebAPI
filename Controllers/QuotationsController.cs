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
    public class QuotationsController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public QuotationsController(SqlServerContext context)
        {
            _context = context;
        }

        // GET: api/Quotations
        [HttpGet("{customerNo}")]
        public async Task<ActionResult<IEnumerable<Quotation>>> GetQuotation(string customerNo)
        {
            var result = await _context.Quotation.FromSqlRaw(
                "SELECT Quotation_ID QuotationId, Validity, " +
                "Expiry_Date ExpiryDate, Description FROM Quotation Q " +
                "WHERE Q.Customer_No=@CustomerNo"
                // + " AND EXISTS (SELECT 1 FROM Direct_Shipment DS WHERE DS.Quotation_ID = Q.Quotation_ID)"
                , new SqlParameter("CustomerNo", customerNo)).ToListAsync();
            if (result == null || result.Count == 0)
            {
                return NotFound();
            }
            return result;
        }

    }
}
