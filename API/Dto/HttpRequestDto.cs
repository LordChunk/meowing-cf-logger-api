using System.Collections.Generic;
using Libs.Models;

namespace API.Dto
{
    public class HttpRequestDto : HttpRequestNoHeader
    {
        public List<List<string>> Headers { get; set; }
    }
}