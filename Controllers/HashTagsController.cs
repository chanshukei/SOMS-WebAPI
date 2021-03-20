using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOMS_WebAPI.Models;
using SOMS_WebAPI.Models.Context;

namespace SOMS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashTagsController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public HashTagsController(SqlServerContext context)
        {
            _context = context;
        }

        // GET: api/HashTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HashTag>>> GetHashTag()
        {
            return await _context.HashTag.ToListAsync();
        }

        // GET: api/HashTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HashTag>> GetHashTag(string id)
        {
            var hashTag = await _context.HashTag.FindAsync(id);

            if (hashTag == null)
            {
                return NotFound();
            }

            return hashTag;
        }

        // PUT: api/HashTags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHashTag(string id, HashTag hashTag)
        {
            if (id != hashTag.Text)
            {
                return BadRequest();
            }

            _context.Entry(hashTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HashTagExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HashTags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HashTag>> PostHashTag(HashTag hashTag)
        {
            _context.HashTag.Add(hashTag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HashTagExists(hashTag.Text))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHashTag", new { id = hashTag.Text }, hashTag);
        }

        // DELETE: api/HashTags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HashTag>> DeleteHashTag(string id)
        {
            var hashTag = await _context.HashTag.FindAsync(id);
            if (hashTag == null)
            {
                return NotFound();
            }

            _context.HashTag.Remove(hashTag);
            await _context.SaveChangesAsync();

            return hashTag;
        }

        private bool HashTagExists(string id)
        {
            return _context.HashTag.Any(e => e.Text == id);
        }
    }
}
