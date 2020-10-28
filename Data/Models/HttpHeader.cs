using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Models.Common;
using Newtonsoft.Json;

namespace Data.Models
{
    public class HttpHeader
    {
        [Required]
        public string Header { get; set; }
        [Required]
        public string Value { get; set; }

        [Required]
        public int HttpRequestId { get; set; }

        [JsonIgnore]
        public virtual HttpRequest HttpRequest { get; set; }
    }
}