using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dto;
using Data;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("[controller]")]
    public class HttpRequestsController : ControllerBase
    {
        private readonly RepositoryWrapper _repositoryWrapper;

        public HttpRequestsController(RepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: api/HttpRequests
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HttpRequest>>> GetHttpRequests() => await _repositoryWrapper.HttpRequest.GetAll();

        // GET: api/HttpRequests/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HttpRequest>> GetHttpRequest(int id)
        {
            var httpRequest = await _repositoryWrapper.HttpRequest.Get(r => r.Id == id);
            if (httpRequest == null) return NotFound();

            return httpRequest;
        }

        // PUT: api/HttpRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutHttpRequest(int id, HttpRequest httpRequest)
        {
            if (id != httpRequest.Id) return BadRequest();
            var result = await _repositoryWrapper.HttpRequest.Update(httpRequest);
            if (result == null) return NotFound();

            return NoContent();
        }

        // POST: api/HttpRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HttpRequest>> PostHttpRequest(HttpRequestDto dto)
        {
            var httpRequest = ConvertDtoToModel(dto);
            await _repositoryWrapper.HttpRequest.Add(httpRequest);

            return CreatedAtAction("GetHttpRequest", new { id = httpRequest.Id }, httpRequest);
        }

        // DELETE: api/HttpRequests/5
        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HttpRequest>> DeleteHttpRequest(int id)
        {
            var httpRequest = await _repositoryWrapper.HttpRequest.Get(r => r.Id == id);
            if (httpRequest == null) return NotFound();
            await _repositoryWrapper.HttpRequest.Remove(httpRequest);

            return httpRequest;
        }

        [HttpGet("recent/{count:int}")]
        public async Task<ActionResult<List<HttpRequest>>> GetRecent(int count = 100) => 
            await _repositoryWrapper.HttpRequest.GetRecentRequests(count);

        private static HttpRequest ConvertDtoToModel(HttpRequestDto dto)
        {
            var model = new HttpRequest
            {
                Body = dto.Body,
                BodyUsed = dto.BodyUsed,
                ContentLength = dto.ContentLength,
                Fetchers = dto.Fetchers,
                //Headers = 
                Id = dto.Id,
                Method = dto.Method,
                Redirect = dto.Redirect,
                Url = new RequestUrl { Url =  dto.Url.Split("?")[0]  },
            };

            var headerList = new List<HttpHeader>();

            dto.Headers.ForEach(header =>
            {
                headerList.Add(new HttpHeader()
                {
                    Header = header[0],
                    Value = header[1],
                });
            });

            model.Headers = headerList;

            return model;
        }
    }
}
