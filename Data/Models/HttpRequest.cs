using System.Collections.Generic;

namespace Data.Models
{
    public class HttpRequest : HttpRequestNoHeader
    {
        public List<HttpHeader> Headers { get; set; }
    }
}