using System.Collections.Generic;
using Data.Models;

namespace API.Dto
{
    public class HttpRequestDto : HttpRequestNoHeader
    {
        public string Url { get; set; }
        public List<List<string>> Headers { get; set; }
    }
}