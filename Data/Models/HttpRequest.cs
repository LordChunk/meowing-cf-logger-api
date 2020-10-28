using System.Collections.Generic;
using Data.Models.Common;

namespace Data.Models
{
    public class HttpRequest : EntityBase
    {
        public string Url { get; set; }
        public CfHttpHeader Cf { get; set; }
        public string Method { get; set; }
        public string Body { get; set; }
        public IList<HttpHeader> Headers { get; set; }
        public string Fetchers { get; set; }
        public bool BodyUsed { get; set; }
        public string Redirect { get; set; }
        public int ContentLength { get; set; }
    }
}