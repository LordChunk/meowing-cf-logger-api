using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Models.Common;

namespace Data.Models
{
    public class HttpHeader : EntityBase
    {
        [Required]
        public string Header { get; set; }
        [Required]
        public string Value { get; set; }

        [Required]
        public int HttpRequestId { get; set; }
        public virtual HttpRequest HttpRequest { get; set; }
    }
}