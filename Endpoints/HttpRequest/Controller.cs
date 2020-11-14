using System.Collections.Generic;
using System.Threading.Tasks;
using Libs.Models;
using Libs.RabbitMQ;
using Libs.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequest
{
    [Route("api/httprequests")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public Controller(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpPost]
        public async Task<ActionResult<Libs.Models.HttpRequest>> PostHttpRequest(HttpRequestDto dto)
        {
            var httpRequest = ConvertDtoToModel(dto);
            var returnValue = await _repositoryWrapper.HttpRequest.Add(httpRequest);

            //return CreatedAtAction("GetHttpRequest", new { id = httpRequest.Id }, httpRequest);

            return Ok(returnValue);
        }

        private Libs.Models.HttpRequest ConvertDtoToModel(HttpRequestDto dto)
        {
            var model = new Libs.Models.HttpRequest()
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
