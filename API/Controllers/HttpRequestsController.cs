using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;
using HttpRequest = Data.Models.HttpRequest;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpRequestsController : ControllerBase
    {
        private readonly MeowingCfLoggerContext _context;

        public HttpRequestsController(MeowingCfLoggerContext context)
        {
            _context = context;
        }

        // GET: api/HttpRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HttpRequest>>> GetHttpRequests()
        {
            return await _context.HttpRequests.ToListAsync();
        }

        // GET: api/HttpRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HttpRequest>> GetHttpRequest(int id)
        {
            var httpRequest = await _context.HttpRequests.FindAsync(id);

            if (httpRequest == null)
            {
                return NotFound();
            }

            return httpRequest;
        }

        // PUT: api/HttpRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHttpRequest(int id, HttpRequest httpRequest)
        {
            if (id != httpRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(httpRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HttpRequestExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/HttpRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HttpRequest>> PostHttpRequest(HttpRequest httpRequest)
        {
            await _context.HttpRequests.AddAsync(httpRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHttpRequest", new { id = httpRequest.Id }, httpRequest);
        }

        // DELETE: api/HttpRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HttpRequest>> DeleteHttpRequest(int id)
        {
            var httpRequest = await _context.HttpRequests.FindAsync(id);
            if (httpRequest == null)
            {
                return NotFound();
            }

            _context.HttpRequests.Remove(httpRequest);
            await _context.SaveChangesAsync();

            return httpRequest;
        }

        private bool HttpRequestExists(int id)
        {
            return _context.HttpRequests.Any(e => e.Id == id);
        }
    }
}
