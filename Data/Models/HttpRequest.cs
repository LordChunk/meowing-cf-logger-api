using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Models.Common;
using Newtonsoft.Json;

namespace Data.Models
{
    public class HttpRequest : EntityBase
    {
        [Required]
        public string Url { get; set; }
        public CfHttpHeader Cf { get; set; }
        [Required]
        public string Method { get; set; }
        public string Body { get; set; }
        public IList<HttpHeader> Headers { get; set; }
        public string Fetchers { get; set; }
        public bool BodyUsed { get; set; }
        public string Redirect { get; set; }
        [Required]
        public int ContentLength { get; set; }
    }
}