using System.Collections.Generic;

namespace Data.Models
{
    public class HttpRequest : HttpRequestNoHeader
    {
        public virtual List<HttpHeader> Headers { get; set; }
    }
}