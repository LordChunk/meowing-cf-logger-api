using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;
using Data.Repositories.Common;
using Data.Repositories.Interfaces;
using HttpRequest = Data.Models.HttpRequest;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpRequestsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public HttpRequestsController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: api/HttpRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HttpRequest>>> GetHttpRequests()
        {
            return await _repositoryWrapper.HttpRequest.FindAll().ToListAsync();
        }

        // GET: api/HttpRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HttpRequest>> GetHttpRequestAsync(int id)
        {
            var httpRequest = await _repositoryWrapper.HttpRequest.FindByCondition(r => r.Id == id).FirstOrDefaultAsync();

            if (httpRequest == null)
            {
                return NotFound();
            }

            return httpRequest;
        }

        // PUT: api/HttpRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutHttpRequest(int id, HttpRequest httpRequest)
        //{
        //    if (id != httpRequest.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _repositoryWrapper.Entry(httpRequest).State = EntityState.Modified;

        //    try
        //    {
        //        await _repositoryWrapper.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HttpRequestExists(id))
        //        {
        //            return NotFound();
        //        }

        //        throw;
        //    }

        //    return NoContent();
        //}

        //// POST: api/HttpRequests
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<HttpRequest>> PostHttpRequest(HttpRequestDto dto)
        //{
        //    var httpRequest = ConvertDtoToModel(dto);
        //    await _repositoryWrapper.HttpRequests.AddAsync(httpRequest);
        //    await _repositoryWrapper.SaveChangesAsync();

        //    return CreatedAtAction("GetHttpRequest", new { id = httpRequest.Id }, httpRequest);
        //}

        //// DELETE: api/HttpRequests/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<HttpRequest>> DeleteHttpRequest(int id)
        //{
        //    var httpRequest = await _repositoryWrapper.HttpRequests.FindAsync(id);
        //    if (httpRequest == null)
        //    {
        //        return NotFound();
        //    }

        //    _repositoryWrapper.HttpRequests.Remove(httpRequest);
        //    await _repositoryWrapper.SaveChangesAsync();

        //    return httpRequest;
        //}

        //private bool HttpRequestExists(int id)
        //{
        //    return _repositoryWrapper.HttpRequests.Any(e => e.Id == id);
        //}

        //private HttpRequest ConvertDtoToModel(HttpRequestDto dto)
        //{
        //    var model = new HttpRequest()
        //    {
        //        Body = dto.Body,
        //        BodyUsed = dto.BodyUsed,
        //        Cf = dto.Cf,
        //        ContentLength = dto.ContentLength,
        //        Fetchers = dto.Fetchers,
        //        //Headers = 
        //        Id = dto.Id,
        //        Method = dto.Method,
        //        Redirect = dto.Redirect,
        //        Url = dto.Url,
        //    };

        //    var headerList = new List<HttpHeader>();

        //    dto.Headers.ForEach(header =>
        //    {
        //        headerList.Add(new HttpHeader()
        //        {
        //            Header = header[0],
        //            Value = header[1],
        //            HttpRequestId = model.Id,
        //        });
        //    });

        //    model.Headers = headerList;

        //    return model;
        //}
    }
}
