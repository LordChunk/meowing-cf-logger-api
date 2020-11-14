using System.Collections.Generic;
using Libs.Models;

namespace HttpRequest
{
    public class HttpRequestDto : HttpRequestNoHeader
    {
        public List<List<string>> Headers { get; set; }
    }
}