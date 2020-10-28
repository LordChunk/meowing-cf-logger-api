using Data.Models.Common;

namespace Data.Models
{
    public class HttpHeader : EntityBase
    {
        public string Header { get; set; }
        public string Value { get; set; }

        public string HttpRequestId { get; set; }
        public HttpRequest HttpRequest { get; set; }
    }
}