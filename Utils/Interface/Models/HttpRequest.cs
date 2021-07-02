using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interface.Models
{
    public class HttpRequest : HttpRequestNoHeader
    {
        [Required]
        public int UrlId { get; set; }
        public virtual RequestUrl Url { get; set; }

        public virtual List<HttpHeader> Headers { get; set; }
    }
}