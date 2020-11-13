using System.Collections.Generic;

namespace Libs.Models
{
    public class HttpRequest : HttpRequestNoHeader
    {
        public virtual List<HttpHeader> Headers { get; set; }
    }
}