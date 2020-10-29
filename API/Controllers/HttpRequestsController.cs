using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
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
        private readonly RepositoryContext _context;

        public HttpRequestsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/HttpRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HttpRequest>>> GetHttpRequests()
        {
            return await _context.HttpRequests.Include(r => r.Headers).ToListAsync();
        }

        // GET: api/HttpRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HttpRequest>> GetHttpRequest(int id)
        {
            var httpRequest = await _context.HttpRequests.Include(r => r.Headers).FirstOrDefaultAsync(r => r.Id == id);

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
        public async Task<ActionResult<HttpRequest>> PostHttpRequest(HttpRequestDto dto)
        {
            var httpRequest = ConvertDtoToModel(dto);
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

        private HttpRequest ConvertDtoToModel(HttpRequestDto dto)
        {
            var model = new HttpRequest()
            {
                Body = dto.Body,
                BodyUsed = dto.BodyUsed,
                Cf = dto.Cf,
                ContentLength = dto.ContentLength,
                Fetchers = dto.Fetchers,
                //Headers = 
                Id = dto.Id,
                Method = dto.Method,
                Redirect = dto.Redirect,
                Url = dto.Url,
            };

            var headerList = new List<HttpHeader>();

            dto.Headers.ForEach(header =>
            {
                headerList.Add(new HttpHeader()
                {
                    Header = header[0],
                    Value = header[1],
                    HttpRequestId = model.Id,
                });
            });

            model.Headers = headerList;

            return model;
        }
    }
}
