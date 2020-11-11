using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dto;
using API.HubConfig;
using Data;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.SignalR;
using HttpRequest = Data.Models.HttpRequest;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpRequestsController : ControllerBase
    {
        private readonly RepositoryWrapper _repositoryWrapper;
        private readonly IHubContext<HttpRequestHub> _hub;

        public HttpRequestsController(RepositoryWrapper repositoryWrapper, IHubContext<HttpRequestHub> hub)
        {
            _repositoryWrapper = repositoryWrapper;
            _hub = hub;
        }

        // GET: api/HttpRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HttpRequest>>> GetHttpRequests()
        {
            return await _repositoryWrapper.HttpRequest.GetAll();
        }

        // GET: api/HttpRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HttpRequest>> GetHttpRequest(int id)
        {
            var httpRequest = await _repositoryWrapper.HttpRequest.Get(r => r.Id == id);

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
        [HttpDelete("{id}")]
        public async Task<ActionResult<HttpRequest>> DeleteHttpRequest(int id)
        {
            var httpRequest = await _repositoryWrapper.HttpRequest.Get(r => r.Id == id);
            if (httpRequest == null)
            {
                return NotFound();
            }

            await _repositoryWrapper.HttpRequest.Remove(httpRequest);

            return httpRequest;
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
